using Turning.Domain.Entities;

namespace Turning.Application.Interfaces;

/// <summary>
/// Puerto para generar texto del interlocutor mediado por IA.
/// </summary>
public interface ITextGenerationPort
{
    /// <summary>
    /// Genera una respuesta del interlocutor a partir de la sesión y el historial conversacional actual.
    /// </summary>
    Task<string> GenerateInterlocutorReplyAsync(ExperimentSession session, IReadOnlyList<ConversationTurn> conversationHistory, CancellationToken cancellationToken = default);
}