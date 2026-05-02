using Turning.Domain.Common;

namespace Turning.Domain.Entities;

/// <summary>
/// Condición experimental base para una sesión.
/// </summary>
public enum ExperimentalCondition
{
    /// <summary>
    /// La sesión se asigna a un interlocutor humano.
    /// </summary>
    Human = 1,

    /// <summary>
    /// La sesión se asigna a un interlocutor basado en IA.
    /// </summary>
    AI = 2
}

/// <summary>
/// Estado de alto nivel de una sesión experimental.
/// </summary>
public enum ExperimentSessionStatus
{
    /// <summary>
    /// La sesión existe y ya puede iniciar conversación, emociones y avatar.
    /// </summary>
    Bootstrapped = 1,

    /// <summary>
    /// La sesión se encuentra en ejecución activa.
    /// </summary>
    Active = 2,

    /// <summary>
    /// La sesión fue cerrada de forma controlada.
    /// </summary>
    Completed = 3
}

/// <summary>
/// Representa una sesión experimental autenticada y persistida.
/// </summary>
public sealed class ExperimentSession : BaseEntity
{
    private ExperimentSession()
    {
    }

    /// <summary>
    /// Identificador del usuario autenticado que abrió la sesión.
    /// </summary>
    public Guid OwnerUserId { get; private set; }

    /// <summary>
    /// Código corto legible para referenciar la sesión.
    /// </summary>
    public string SessionCode { get; private set; } = string.Empty;

    /// <summary>
    /// Condición experimental asignada.
    /// </summary>
    public ExperimentalCondition Condition { get; private set; }

    /// <summary>
    /// Estado actual de la sesión.
    /// </summary>
    public ExperimentSessionStatus Status { get; private set; }

    /// <summary>
    /// Estado base del avatar asociado a la sesión.
    /// </summary>
    public string AvatarState { get; private set; } = string.Empty;

    /// <summary>
    /// Última emoción detectada dentro de la sesión.
    /// </summary>
    public string? LastDetectedEmotion { get; private set; }

    /// <summary>
    /// Número de turnos conversacionales registrados.
    /// </summary>
    public int ConversationTurnCount { get; private set; }

    /// <summary>
    /// Número de muestras emocionales registradas.
    /// </summary>
    public int EmotionSampleCount { get; private set; }

    /// <summary>
    /// Crea una sesión experimental en estado inicial.
    /// </summary>
    public static ExperimentSession Create(Guid ownerUserId, ExperimentalCondition condition)
    {
        if (ownerUserId == Guid.Empty)
            throw new ArgumentException("El identificador del usuario es obligatorio.", nameof(ownerUserId));

        var sessionId = Guid.NewGuid();

        return new ExperimentSession
        {
            Id = sessionId,
            OwnerUserId = ownerUserId,
            SessionCode = BuildSessionCode(sessionId),
            Condition = condition,
            Status = ExperimentSessionStatus.Bootstrapped,
            AvatarState = "Neutral",
            ConversationTurnCount = 0,
            EmotionSampleCount = 0,
            CreatedAt = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Registra actividad conversacional en la sesión y la marca como activa.
    /// </summary>
    public void RegisterConversationTurn()
    {
        ConversationTurnCount++;

        if (Status == ExperimentSessionStatus.Bootstrapped)
        {
            Status = ExperimentSessionStatus.Active;
        }

        UpdatedAt = DateTime.UtcNow;
    }

    private static string BuildSessionCode(Guid sessionId)
    {
        return $"EXP-{sessionId.ToString("N")[..8].ToUpperInvariant()}";
    }
}