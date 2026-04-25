using Turning.Domain.Entities;

namespace Turning.Application.Interfaces;

/// <summary>
/// Interfaz del repositorio para la entidad SampleEntity.
/// Define el contrato para operaciones sobre SampleEntity en la persistencia.
/// </summary>
public interface ISampleRepository
{
    /// <summary>
    /// Obtiene todas las entidades de muestra.
    /// </summary>
    /// <param name="cancellationToken">Token de cancelación.</param>
    /// <returns>Colección de todas las entidades de muestra.</returns>
    Task<IEnumerable<SampleEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene una entidad de muestra por su identificador.
    /// </summary>
    /// <param name="id">Identificador de la entidad.</param>
    /// <param name="cancellationToken">Token de cancelación.</param>
    /// <returns>La entidad si existe, null en caso contrario.</returns>
    Task<SampleEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Añade una nueva entidad de muestra.
    /// </summary>
    /// <param name="entity">La entidad a añadir.</param>
    /// <param name="cancellationToken">Token de cancelación.</param>
    Task AddAsync(SampleEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Actualiza una entidad de muestra existente.
    /// </summary>
    /// <param name="entity">La entidad a actualizar.</param>
    /// <param name="cancellationToken">Token de cancelación.</param>
    Task UpdateAsync(SampleEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Elimina una entidad de muestra.
    /// </summary>
    /// <param name="id">Identificador de la entidad a eliminar.</param>
    /// <param name="cancellationToken">Token de cancelación.</param>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
