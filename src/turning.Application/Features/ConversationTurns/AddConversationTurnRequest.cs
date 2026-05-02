namespace Turning.Application.Features.ConversationTurns;

/// <summary>
/// Solicitud para registrar un nuevo mensaje dentro de una sesión.
/// </summary>
public sealed class AddConversationTurnRequest
{
    /// <summary>
    /// Actor emisor del mensaje.
    /// </summary>
    public string Sender { get; init; } = "Participant";

    /// <summary>
    /// Texto del mensaje.
    /// </summary>
    public string Message { get; init; } = string.Empty;
}