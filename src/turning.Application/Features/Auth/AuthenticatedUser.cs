namespace Turning.Application.Features.Auth;

/// <summary>
/// Usuario autenticado expuesto al cliente.
/// </summary>
public sealed class AuthenticatedUser
{
    /// <summary>
    /// Identificador del usuario.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Nombre visible del usuario.
    /// </summary>
    public required string FullName { get; init; }

    /// <summary>
    /// Correo electrónico del usuario.
    /// </summary>
    public required string Email { get; init; }

    /// <summary>
    /// Rol actual del usuario.
    /// </summary>
    public required string Role { get; init; }
}