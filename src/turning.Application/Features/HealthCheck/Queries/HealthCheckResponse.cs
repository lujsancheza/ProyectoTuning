namespace Turning.Application.Features.HealthCheck.Queries;

/// <summary>
/// Respuesta del check de salud.
/// </summary>
public class HealthCheckResponse
{
    /// <summary>
    /// Indica si el sistema está saludable.
    /// </summary>
    public bool IsHealthy { get; set; } = true;

    /// <summary>
    /// Mensaje de estado.
    /// </summary>
    public string Status { get; set; } = "OK";

    /// <summary>
    /// Marca de tiempo del check.
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Información adicional.
    /// </summary>
    public string? Message { get; set; }
}
