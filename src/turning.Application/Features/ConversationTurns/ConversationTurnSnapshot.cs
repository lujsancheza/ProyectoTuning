namespace Turning.Application.Features.ConversationTurns;

/// <summary>
/// DTO resumido de un turno conversacional persistido.
/// </summary>
public sealed class ConversationTurnSnapshot
{
    /// <summary>
    /// Identificador del turno.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Identificador de la sesión a la que pertenece.
    /// </summary>
    public Guid SessionId { get; init; }

    /// <summary>
    /// Orden secuencial del turno.
    /// </summary>
    public int SequenceNumber { get; init; }

    /// <summary>
    /// Actor que emitió el mensaje.
    /// </summary>
    public required string Sender { get; init; }

    /// <summary>
    /// Texto del mensaje.
    /// </summary>
    public required string Message { get; init; }

    /// <summary>
    /// Fecha de creación del turno en UTC.
    /// </summary>
    public DateTime CreatedAtUtc { get; init; }
}