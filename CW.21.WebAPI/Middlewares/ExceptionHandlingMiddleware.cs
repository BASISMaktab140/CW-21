using System.Net;
using System.Text.Json;
using CW._21.WebAPI.Commons;
using CW._21.WebAPI.Exceptions;

namespace CW._21.WebAPI.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            _logger.LogWarning("NotFoundException: {Message}", ex.Message);
            await WriteErrorResponse(context, ex.Message, HttpStatusCode.NotFound);
        }
        catch (BadRequestException ex)
        {
            _logger.LogWarning("BadRequestException: {Message}", ex.Message);
            await WriteErrorResponse(context, ex.Message, HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred.");
            await WriteErrorResponse(context, "An unexpected error occurred. Please try again later.", HttpStatusCode.InternalServerError);
        }
    }

    private static async Task WriteErrorResponse(HttpContext context, string message, HttpStatusCode statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var result = ApiResult.Failure(message, (int)statusCode);

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var json = JsonSerializer.Serialize(result, options);

        await context.Response.WriteAsync(json);
    }
}