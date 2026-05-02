namespace Turning.Application.Features.ConversationTurns;

/// <summary>
/// Casos de uso para listar y registrar mensajes en una sesión experimental.
/// </summary>
public interface IConversationTurnService
{
    /// <summary>
    /// Devuelve la conversación persistida de una sesión autenticada.
    /// </summary>
    Task<IReadOnlyList<ConversationTurnSnapshot>> ListAsync(Guid ownerUserId, Guid sessionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Agrega un mensaje a una sesión autenticada.
    /// </summary>
    Task<ConversationTurnSnapshot> AddAsync(Guid ownerUserId, Guid sessionId, AddConversationTurnRequest request, CancellationToken cancellationToken = default);
}