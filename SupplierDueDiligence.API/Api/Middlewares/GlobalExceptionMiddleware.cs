using System.Text.Json;
using System.Text.Json.Serialization;
using SupplierDueDiligence.API.Config.Exceptions;
using SupplierDueDiligence.API.Infraestructure.Shared.ApiResponse;

namespace SupplierDueDiligence.API.Api.Middlewares;

public class GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);

            var path = context.Request.Path;
            var statusCode = context.Response.StatusCode;
            if (statusCode == 404) throw new NotFoundException($"No resource found for path: {path}");
            if (statusCode == 405) throw new MethodNotAllowedException(context.Request.Method);
            if (statusCode == 401) throw new UnauthorizedException($"User does not have access to the requested path: {path}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception caught.");
            var response = ApiResponse<object>.Exception(ex);
            await HandleExceptionAsync(context, response);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, ApiResponse<object> response)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = response.Error!.Code;

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter() }
        };
        var json = JsonSerializer.Serialize(response, options);
        return context.Response.WriteAsync(json);
    }
}