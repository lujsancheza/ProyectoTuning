using Microsoft.EntityFrameworkCore;
using Turning.Domain.Entities;

namespace Turning.Infrastructure.Persistence;

/// <summary>
/// DbContext principal de la solución.
/// </summary>
public sealed class TurningDbContext : DbContext
{
    /// <summary>
    /// Constructor del contexto.
    /// </summary>
    public TurningDbContext(DbContextOptions<TurningDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Usuarios autenticables persistidos.
    /// </summary>
    public DbSet<UserAccount> UserAccounts => Set<UserAccount>();

    /// <summary>
    /// Sesiones experimentales persistidas.
    /// </summary>
    public DbSet<ExperimentSession> ExperimentSessions => Set<ExperimentSession>();

    /// <summary>
    /// Turnos de conversación persistidos.
    /// </summary>
    public DbSet<ConversationTurn> ConversationTurns => Set<ConversationTurn>();

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.ToTable("UserAccounts");

            entity.HasKey(user => user.Id);
            entity.Property(user => user.Email).IsRequired().HasMaxLength(200);
            entity.Property(user => user.NormalizedEmail).IsRequired().HasMaxLength(200);
            entity.Property(user => user.FullName).IsRequired().HasMaxLength(200);
            entity.Property(user => user.PasswordHash).IsRequired().HasMaxLength(1000);
            entity.Property(user => user.Role).IsRequired().HasMaxLength(50);
            entity.HasIndex(user => user.NormalizedEmail).IsUnique();
        });

        modelBuilder.Entity<ExperimentSession>(entity =>
        {
            entity.ToTable("ExperimentSessions");

            entity.HasKey(session => session.Id);
            entity.Property(session => session.SessionCode).IsRequired().HasMaxLength(20);
            entity.Property(session => session.OwnerUserId).IsRequired();
            entity.Property(session => session.Condition).HasConversion<string>().IsRequired().HasMaxLength(20);
            entity.Property(session => session.Status).HasConversion<string>().IsRequired().HasMaxLength(30);
            entity.Property(session => session.AvatarState).IsRequired().HasMaxLength(50);
            entity.Property(session => session.LastDetectedEmotion).HasMaxLength(50);
            entity.HasIndex(session => session.SessionCode).IsUnique();
            entity.HasIndex(session => new { session.OwnerUserId, session.CreatedAt });
        });

        modelBuilder.Entity<ConversationTurn>(entity =>
        {
            entity.ToTable("ConversationTurns");

            entity.HasKey(turn => turn.Id);
            entity.Property(turn => turn.ExperimentSessionId).IsRequired();
            entity.Property(turn => turn.SequenceNumber).IsRequired();
            entity.Property(turn => turn.Sender).HasConversion<string>().IsRequired().HasMaxLength(20);
            entity.Property(turn => turn.Message).IsRequired().HasMaxLength(4000);
            entity.HasIndex(turn => new { turn.ExperimentSessionId, turn.SequenceNumber }).IsUnique();
            entity.HasOne<ExperimentSession>()
                .WithMany()
                .HasForeignKey(turn => turn.ExperimentSessionId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        base.OnModelCreating(modelBuilder);
    }
}