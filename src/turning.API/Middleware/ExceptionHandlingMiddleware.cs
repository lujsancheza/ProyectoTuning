namespace Turning.API.Middleware;

/// <summary>
/// Middleware para manejo global de excepciones.
/// </summary>
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    /// <summary>
    /// Constructor del middleware de excepción.
    /// </summary>
    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Invoca el middleware.
    /// </summary>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Excepción no manejada en la solicitud");
            await HandleExceptionAsync(context, ex);
        }
    }

    /// <summary>
    /// Maneja la excepción y genera una respuesta HTTP apropiada.
    /// </summary>
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var response = new
        {
            message = "Ocurrió un error interno en el servidor",
            type = exception.GetType().Name,
            details = exception.Message
        };

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        return context.Response.WriteAsJsonAsync(response);
    }
}

/// <summary>
/// Extensiones para agregar el middleware de excepción.
/// </summary>
public static class ExceptionHandlingMiddlewareExtensions
{
    /// <summary>
    /// Usa el middleware de manejo de excepciones.
    /// </summary>
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
