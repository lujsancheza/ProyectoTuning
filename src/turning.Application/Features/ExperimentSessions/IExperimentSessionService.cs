namespace Turning.Application.Features.ExperimentSessions;

/// <summary>
/// Casos de uso de bootstrap y consulta de sesiones experimentales.
/// </summary>
public interface IExperimentSessionService
{
    /// <summary>
    /// Crea una sesión experimental inicial para el usuario autenticado.
    /// </summary>
    Task<ExperimentSessionSnapshot> CreateBootstrapSessionAsync(Guid ownerUserId, CreateExperimentSessionRequest? request = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene la sesión más reciente del usuario autenticado.
    /// </summary>
    Task<ExperimentSessionSnapshot?> GetLatestSessionAsync(Guid ownerUserId, CancellationToken cancellationToken = default);
}