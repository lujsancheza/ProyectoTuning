using Turning.Domain.Entities;

namespace Turning.Application.Interfaces;

/// <summary>
/// Contrato para hashing y verificación de contraseñas.
/// </summary>
public interface IPasswordHasherService
{
    /// <summary>
    /// Genera el hash de la contraseña para un usuario.
    /// </summary>
    string HashPassword(UserAccount userAccount, string password);

    /// <summary>
    /// Verifica una contraseña contra el hash persistido.
    /// </summary>
    bool VerifyPassword(UserAccount userAccount, string providedPassword);
}