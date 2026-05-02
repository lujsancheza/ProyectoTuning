using Turning.Application.Exceptions;
using Turning.Application.Interfaces;
using Turning.Domain.Entities;
using TurningApplicationException = Turning.Application.Exceptions.ApplicationException;

namespace Turning.Application.Features.ExperimentSessions;

/// <summary>
/// Implementa el bootstrap inicial de sesiones experimentales.
/// </summary>
public sealed class ExperimentSessionService : IExperimentSessionService
{
    private readonly IExperimentSessionRepository _experimentSessionRepository;

    /// <summary>
    /// Constructor del servicio de sesiones experimentales.
    /// </summary>
    public ExperimentSessionService(IExperimentSessionRepository experimentSessionRepository)
    {
        _experimentSessionRepository = experimentSessionRepository;
    }

    /// <inheritdoc />
    public async Task<ExperimentSessionSnapshot> CreateBootstrapSessionAsync(Guid ownerUserId, CreateExperimentSessionRequest? request = null, CancellationToken cancellationToken = default)
    {
        if (ownerUserId == Guid.Empty)
            throw new TurningApplicationException("No fue posible resolver el usuario autenticado para crear la sesion.", "SESSION_INVALID_OWNER");

        var condition = ParseCondition(request?.PreferredCondition);
        var session = ExperimentSession.Create(ownerUserId, condition);

        await _experimentSessionRepository.AddAsync(session, cancellationToken);
        await _experimentSessionRepository.SaveChangesAsync(cancellationToken);

        return Map(session);
    }

    /// <inheritdoc />
    public async Task<ExperimentSessionSnapshot?> GetLatestSessionAsync(Guid ownerUserId, CancellationToken cancellationToken = default)
    {
        if (ownerUserId == Guid.Empty)
            throw new TurningApplicationException("No fue posible resolver el usuario autenticado para consultar la sesion.", "SESSION_INVALID_OWNER");

        var session = await _experimentSessionRepository.GetLatestByOwnerAsync(ownerUserId, cancellationToken);
        return session is null ? null : Map(session);
    }

    private static ExperimentalCondition ParseCondition(string? preferredCondition)
    {
        if (string.IsNullOrWhiteSpace(preferredCondition))
        {
            return ExperimentalCondition.AI;
        }

        return preferredCondition.Trim().ToUpperInvariant() switch
        {
            "AI" => ExperimentalCondition.AI,
            "HUMAN" => ExperimentalCondition.Human,
            _ => throw new TurningApplicationException("La condicion experimental debe ser AI o Human.", "SESSION_INVALID_CONDITION")
        };
    }

    private static ExperimentSessionSnapshot Map(ExperimentSession session)
    {
        return new ExperimentSessionSnapshot
        {
            Id = session.Id,
            SessionCode = session.SessionCode,
            Condition = session.Condition.ToString(),
            Status = session.Status.ToString(),
            AvatarState = session.AvatarState,
            ConversationTurnCount = session.ConversationTurnCount,
            EmotionSampleCount = session.EmotionSampleCount,
            LastDetectedEmotion = session.LastDetectedEmotion,
            CreatedAtUtc = session.CreatedAt,
            ConversationStage = session.ConversationTurnCount == 0 ? "ready-for-first-turn" : "in-progress",
            EmotionStage = session.EmotionSampleCount == 0 ? "ready-for-first-signal" : "monitoring",
            AvatarStage = session.AvatarState
        };
    }
}