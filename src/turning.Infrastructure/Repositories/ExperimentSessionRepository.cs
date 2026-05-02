using Microsoft.EntityFrameworkCore;
using Turning.Application.Interfaces;
using Turning.Domain.Entities;
using Turning.Infrastructure.Persistence;

namespace Turning.Infrastructure.Repositories;

/// <summary>
/// Repositorio EF Core para sesiones experimentales.
/// </summary>
public sealed class ExperimentSessionRepository : IExperimentSessionRepository
{
    private readonly TurningDbContext _dbContext;

    /// <summary>
    /// Constructor del repositorio de sesiones.
    /// </summary>
    public ExperimentSessionRepository(TurningDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task AddAsync(ExperimentSession session, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        await _dbContext.ExperimentSessions.AddAsync(session, cancellationToken);
    }

    /// <inheritdoc />
    public Task<ExperimentSession?> GetByIdAsync(Guid sessionId, CancellationToken cancellationToken = default)
    {
        return _dbContext.ExperimentSessions
            .FirstOrDefaultAsync(session => session.Id == sessionId && !session.IsDeleted, cancellationToken);
    }

    /// <inheritdoc />
    public Task<ExperimentSession?> GetLatestByOwnerAsync(Guid ownerUserId, CancellationToken cancellationToken = default)
    {
        return _dbContext.ExperimentSessions
            .Where(session => session.OwnerUserId == ownerUserId && !session.IsDeleted)
            .OrderByDescending(session => session.CreatedAt)
            .FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc />
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}