namespace Turning.Application.Features.Auth;

/// <summary>
/// Solicitud para autenticar un usuario existente.
/// </summary>
public sealed class LoginRequest
{
    /// <summary>
    /// Correo electrónico del usuario.
    /// </summary>
    public required string Email { get; init; }

    /// <summary>
    /// Contraseña en texto plano.
    /// </summary>
    public required string Password { get; init; }
}