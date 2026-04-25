using Turning.Domain.Common;

namespace Turning.Domain.Entities;

/// <summary>
/// Entidad de ejemplo para demostrar la estructura de una entidad de dominio.
/// </summary>
public class SampleEntity : BaseEntity
{
    /// <summary>
    /// Nombre de la entidad de ejemplo.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Descripción de la entidad de ejemplo.
    /// </summary>
    public string? Description { get; private set; }

    /// <summary>
    /// Indica si la entidad está activa.
    /// </summary>
    public bool IsActive { get; private set; } = true;

    /// <summary>
    /// Constructor privado para uso de EF Core y métodos de creación.
    /// </summary>
#pragma warning disable CS8618
    private SampleEntity()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// Factory method para crear una nueva instancia de SampleEntity.
    /// </summary>
    /// <param name="name">Nombre de la entidad.</param>
    /// <param name="description">Descripción opcional de la entidad.</param>
    /// <returns>Una nueva instancia de SampleEntity.</returns>
    public static SampleEntity Create(string name, string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre no puede estar vacío.", nameof(name));

        return new SampleEntity
        {
            Id = Guid.NewGuid(),
            Name = name.Trim(),
            Description = description?.Trim(),
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Actualiza el nombre de la entidad.
    /// </summary>
    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre no puede estar vacío.", nameof(name));

        Name = name.Trim();
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Actualiza la descripción de la entidad.
    /// </summary>
    public void UpdateDescription(string? description)
    {
        Description = description?.Trim();
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Desactiva la entidad.
    /// </summary>
    public void Deactivate()
    {
        if (!IsActive)
            return;

        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Activa la entidad.
    /// </summary>
    public void Activate()
    {
        if (IsActive)
            return;

        IsActive = true;
        UpdatedAt = DateTime.UtcNow;
    }
}
