namespace Turning.Application.Features.HealthCheck.Queries;

/// <summary>
/// Query para verificar el estado de salud de la aplicación.
/// </summary>
public class GetHealthQuery
{
    /// <summary>
    /// Obtiene o establece un mensaje opcional para la consulta de salud.
    /// </summary>
    public string? Message { get; set; }
}
