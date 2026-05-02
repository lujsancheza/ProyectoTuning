using Turning.Application.Features.Auth;
using Turning.Domain.Entities;

namespace Turning.Application.Interfaces;

/// <summary>
/// Contrato para emisión de tokens de autenticación.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Crea el resultado autenticado para el usuario dado.
    /// </summary>
    AuthResult CreateToken(UserAccount userAccount);
}