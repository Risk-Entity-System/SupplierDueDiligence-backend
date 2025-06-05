using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SupplierDueDiligence.API.Config;
using SupplierDueDiligence.API.Config.Exceptions;
using SupplierDueDiligence.API.Config.Helpers;
using SupplierDueDiligence.API.Data;
using SupplierDueDiligence.API.Domain.Models;
using SupplierDueDiligence.API.Infraestructure.Dtos.Screening;
using SupplierDueDiligence.API.Infraestructure.Shared.ApiResponse;

namespace SupplierDueDiligence.API.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ScreeningController(
    AppDbContext context,
    IHttpClientFactory httpClientFactory,
    IOptions<InternalSettings> settings,
    DeserializerHelper deserializerHelper
    ) : ControllerBase
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient();
    private readonly DeserializerHelper _deserializer = deserializerHelper;
    private readonly InternalSettings _settings = settings.Value;

    [HttpGet("sources")]
    public async Task<IActionResult> GetSources()
    {
        var sources = await context.ScreeningSources
            .AsNoTracking()
            .OrderBy(s => s.Name)
            .ToListAsync();

        var response = ApiResponse<List<ScreeningSource>>.Success("Screening sources retrieved successfully.", sources);

        return Ok(response);
    }

    [HttpGet("{supplierId}")]
    public async Task<IActionResult> ScreenSupplier(int supplierId, [FromQuery] string? sources)
    {
        var supplier = await context.Suppliers
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == supplierId)
            ?? throw new SupplierNotFoundException(supplierId);


        var apiUrl = $"{_settings.InternalApiUrl}/screening?name={supplier.BusinessName}&sources={sources}";
        var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
        request.Headers.Add("x-internal-key", _settings.InternalSecretKey);

        HttpResponseMessage response = await _httpClient.SendAsync(request);

        string content = await response.Content.ReadAsStringAsync();

        var data = _deserializer.DeserializeAsync<ApiResponse<ScrappingResponse>>(content) ?? throw new InternalServerException(
                    details: "Deserialization returned null or malformed JSON.",
                    message: "Something unexpected happened while retrieving data from the selected sources."
                );


        data.ThrowException();

        return Ok(data);
    }
}
