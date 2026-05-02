namespace Turning.Application.Features.Auth;

/// <summary>
/// Resultado estándar de autenticación.
/// </summary>
public sealed class AuthResult
{
    /// <summary>
    /// Token JWT emitido para el usuario.
    /// </summary>
    public required string AccessToken { get; init; }

    /// <summary>
    /// Fecha de expiración del token en UTC.
    /// </summary>
    public required DateTime ExpiresAtUtc { get; init; }

    /// <summary>
    /// Datos del usuario autenticado.
    /// </summary>
    public required AuthenticatedUser User { get; init; }
}