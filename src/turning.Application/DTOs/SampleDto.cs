namespace Turning.Application.DTOs;

/// <summary>
/// DTO para representar una entidad de muestra.
/// Se utiliza para transferir datos entre capas.
/// </summary>
public class SampleDto
{
    /// <summary>
    /// Identificador único de la entidad.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Nombre de la entidad.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Descripción de la entidad.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Indica si la entidad está activa.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Fecha de creación.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Fecha de última actualización.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
