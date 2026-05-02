using Turning.Domain.Entities;

namespace Turning.Application.Interfaces;

/// <summary>
/// Contrato de persistencia para sesiones experimentales.
/// </summary>
public interface IExperimentSessionRepository
{
    /// <summary>
    /// Persiste una nueva sesión experimental.
    /// </summary>
    Task AddAsync(ExperimentSession session, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene una sesión por identificador.
    /// </summary>
    Task<ExperimentSession?> GetByIdAsync(Guid sessionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene la sesión más reciente para un usuario autenticado.
    /// </summary>
    Task<ExperimentSession?> GetLatestByOwnerAsync(Guid ownerUserId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Guarda cambios pendientes.
    /// </summary>
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}