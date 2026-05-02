using Turning.Application.Interfaces;
using Turning.Domain.Entities;

namespace Turning.Infrastructure.AI;

/// <summary>
/// Adapter base para la generación de texto mientras no se conecte OpenAI.
/// </summary>
public sealed class RuleBasedTextGenerationAdapter : ITextGenerationPort
{
    /// <inheritdoc />
    public Task<string> GenerateInterlocutorReplyAsync(ExperimentSession session, IReadOnlyList<ConversationTurn> conversationHistory, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        ArgumentNullException.ThrowIfNull(conversationHistory);

        var latestParticipantTurn = conversationHistory
            .LastOrDefault(turn => turn.Sender == ConversationActor.Participant)?.Message;

        if (string.IsNullOrWhiteSpace(latestParticipantTurn))
        {
            return Task.FromResult("Estoy listo para continuar con la sesion experimental.");
        }

        var normalizedExcerpt = latestParticipantTurn.Trim();

        if (normalizedExcerpt.Length > 140)
        {
            normalizedExcerpt = normalizedExcerpt[..140].TrimEnd() + "...";
        }

        return Task.FromResult($"Entiendo: \"{normalizedExcerpt}\". Sigamos con la siguiente intervencion del experimento.");
    }
}