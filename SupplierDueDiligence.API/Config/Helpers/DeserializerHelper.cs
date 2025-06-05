using System.Text.Json;
using System.Text.Json.Serialization;
using SupplierDueDiligence.API.Infraestructure.Shared.ApiResponse;

namespace SupplierDueDiligence.API.Config.Helpers;

public class DeserializerHelper(ILogger<DeserializerHelper> logger)
{
    private readonly ILogger<DeserializerHelper> _logger = logger;
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter() }
    };

    public T? DeserializeAsync<T>(string content)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(content, _options);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Error deserializing response content. Content: {Content}", content);
            return default;
        }
    }
}
