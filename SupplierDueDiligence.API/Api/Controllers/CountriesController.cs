namespace SupplierDueDiligence.API.Api.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplierDueDiligence.API.Data;
using SupplierDueDiligence.API.Infraestructure.Dtos.Countries;
using SupplierDueDiligence.API.Infraestructure.Shared.ApiResponse;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CountriesController(AppDbContext context) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetResources()
    {
        var countries = await context.Countries
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .ToListAsync();

        var response = ApiResponse<List<CountryDto>>.Success("Countries retrieved successfully.", [.. countries.Select(CountryDto.FromEntity)]);

        return Ok(response);
    }
}