using Turning.Domain.Entities;

namespace Turning.Application.Interfaces;

/// <summary>
/// Contrato de persistencia para turnos conversacionales.
/// </summary>
public interface IConversationTurnRepository
{
    /// <summary>
    /// Agrega un turno de conversación a la persistencia.
    /// </summary>
    Task AddAsync(ConversationTurn turn, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lista los turnos de una sesión ordenados por secuencia.
    /// </summary>
    Task<IReadOnlyList<ConversationTurn>> ListBySessionAsync(Guid sessionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Guarda cambios pendientes de la conversación.
    /// </summary>
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}