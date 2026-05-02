using Microsoft.EntityFrameworkCore;
using Turning.Application.Interfaces;
using Turning.Domain.Entities;
using Turning.Infrastructure.Persistence;

namespace Turning.Infrastructure.Repositories;

/// <summary>
/// Repositorio EF Core para cuentas de usuario.
/// </summary>
public sealed class UserAccountRepository : IUserAccountRepository
{
    private readonly TurningDbContext _dbContext;

    /// <summary>
    /// Constructor del repositorio de usuarios.
    /// </summary>
    public UserAccountRepository(TurningDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public Task<UserAccount?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var normalizedEmail = UserAccount.NormalizeEmail(email);

        return _dbContext.UserAccounts
            .FirstOrDefaultAsync(user => user.NormalizedEmail == normalizedEmail && !user.IsDeleted, cancellationToken);
    }

    /// <inheritdoc />
    public Task<UserAccount?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return _dbContext.UserAccounts
            .FirstOrDefaultAsync(user => user.Id == userId && !user.IsDeleted, cancellationToken);
    }

    /// <inheritdoc />
    public Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var normalizedEmail = UserAccount.NormalizeEmail(email);

        return _dbContext.UserAccounts
            .AnyAsync(user => user.NormalizedEmail == normalizedEmail && !user.IsDeleted, cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddAsync(UserAccount userAccount, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(userAccount);

        await _dbContext.UserAccounts.AddAsync(userAccount, cancellationToken);
    }

    /// <inheritdoc />
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}