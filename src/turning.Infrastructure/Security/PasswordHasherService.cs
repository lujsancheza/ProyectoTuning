using Microsoft.AspNetCore.Identity;
using Turning.Application.Interfaces;
using Turning.Domain.Entities;

namespace Turning.Infrastructure.Security;

/// <summary>
/// Servicio de hashing de contraseñas basado en ASP.NET Core Identity.
/// </summary>
public sealed class PasswordHasherService : IPasswordHasherService
{
    private readonly PasswordHasher<UserAccount> _passwordHasher = new();

    /// <inheritdoc />
    public string HashPassword(UserAccount userAccount, string password)
    {
        ArgumentNullException.ThrowIfNull(userAccount);

        return _passwordHasher.HashPassword(userAccount, password);
    }

    /// <inheritdoc />
    public bool VerifyPassword(UserAccount userAccount, string providedPassword)
    {
        ArgumentNullException.ThrowIfNull(userAccount);

        var result = _passwordHasher.VerifyHashedPassword(userAccount, userAccount.PasswordHash, providedPassword);
        return result is PasswordVerificationResult.Success or PasswordVerificationResult.SuccessRehashNeeded;
    }
}