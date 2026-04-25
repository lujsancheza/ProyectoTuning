namespace Turning.Domain.Common;

/// <summary>
/// Clase base para todos los eventos de dominio.
/// Los eventos de dominio representan algo importante que ha sucedido en el dominio.
/// </summary>
public abstract class DomainEvent
{
    /// <summary>
    /// Obtiene la fecha y hora en que ocurrió el evento.
    /// </summary>
    public DateTime OccurredAt { get; } = DateTime.UtcNow;

    /// <summary>
    /// Obtiene el identificador único del evento.
    /// </summary>
    public Guid EventId { get; } = Guid.NewGuid();
}
