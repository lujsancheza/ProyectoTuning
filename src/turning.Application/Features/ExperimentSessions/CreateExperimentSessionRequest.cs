namespace Turning.Application.Features.ExperimentSessions;

/// <summary>
/// Solicitud para crear una sesión experimental inicial.
/// </summary>
public sealed class CreateExperimentSessionRequest
{
    /// <summary>
    /// Condición experimental preferida para el bootstrap inicial.
    /// </summary>
    public string PreferredCondition { get; init; } = "AI";
}