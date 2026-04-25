namespace Turning.Domain.Common;

/// <summary>
/// Entidad base para todas las entidades del dominio.
/// Proporciona propiedades comunes como ID y marcas de tiempo.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Identificador único de la entidad.
    /// </summary>
    public Guid Id { get; protected set; } = Guid.NewGuid();

    /// <summary>
    /// Fecha de creación de la entidad.
    /// </summary>
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;

    /// <summary>
    /// Fecha de última actualización de la entidad.
    /// </summary>
    public DateTime? UpdatedAt { get; protected set; }

    /// <summary>
    /// Indica si la entidad ha sido eliminada lógicamente.
    /// </summary>
    public bool IsDeleted { get; protected set; } = false;

    /// <summary>
    /// Lista de eventos de dominio que han ocurrido en esta entidad.
    /// </summary>
    private readonly List<DomainEvent> _domainEvents = [];

    /// <summary>
    /// Obtiene una copia de los eventos de dominio.
    /// </summary>
    public IReadOnlyCollection<DomainEvent> GetDomainEvents() => _domainEvents.AsReadOnly();

    /// <summary>
    /// Añade un evento de dominio a la entidad.
    /// </summary>
    protected void AddDomainEvent(DomainEvent @event) => _domainEvents.Add(@event);

    /// <summary>
    /// Limpia todos los eventos de dominio.
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();
}
