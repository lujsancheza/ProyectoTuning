using Microsoft.AspNetCore.Mvc;
using Turning.Application.Features.HealthCheck.Queries;

namespace Turning.API.Controllers;

/// <summary>
/// Controller de health check para verificar el estado de la API.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class HealthController : ControllerBase
{
    private readonly ILogger<HealthController> _logger;

    /// <summary>
    /// Constructor del controller de health.
    /// </summary>
    public HealthController(ILogger<HealthController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Verifica el estado de salud de la aplicación.
    /// </summary>
    /// <remarks>
    /// Endpoint de diagnóstico que devuelve el estado actual del sistema.
    /// 
    /// Ejemplo de respuesta:
    /// ```
    /// {
    ///   "isHealthy": true,
    ///   "status": "OK",
    ///   "timestamp": "2026-03-12T10:30:00Z",
    ///   "message": "Todo está funcionando correctamente"
    /// }
    /// ```
    /// </remarks>
    /// <returns>Estado de salud de la aplicación.</returns>
    [HttpGet]
    public IActionResult GetHealth()
    {
        _logger.LogInformation("Health check solicitado");

        var response = new HealthCheckResponse
        {
            IsHealthy = true,
            Status = "OK",
            Timestamp = DateTime.UtcNow,
            Message = "Todo está funcionando correctamente"
        };

        return Ok(response);
    }

    /// <summary>
    /// Verifica el estado de salud con un mensaje personalizado.
    /// </summary>
    /// <param name="message">Mensaje personalizado para el check.</param>
    /// <returns>Estado de salud con el mensaje personalizado.</returns>
    [HttpGet("status")]
    public IActionResult GetStatus([FromQuery] string? message)
    {
        _logger.LogInformation("Health check status solicitado con mensaje: {Message}", message);

        var response = new HealthCheckResponse
        {
            IsHealthy = true,
            Status = "OK",
            Timestamp = DateTime.UtcNow,
            Message = message ?? "Sistema operativo"
        };

        return Ok(response);
    }
}
