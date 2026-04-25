using Turning.Application.DTOs;
using Turning.Application.Interfaces;
using Turning.Domain.Entities;

namespace Turning.Infrastructure.Repositories;

/// <summary>
/// Implementación en memoria del repositorio ISampleRepository.
/// Se utiliza como ejemplo y para desarrollo sin base de datos.
/// IMPORTANTE: Esta es una implementación temporal. Debe ser reemplazada con 
/// una implementación persistente real (EF Core, ADO.NET, etc.) en producción.
/// </summary>
public class InMemorySampleRepository : ISampleRepository
{
    /// <summary>
    /// Almacenamiento en memoria de las entidades.
    /// </summary>
    private static readonly List<SampleEntity> _samples = [];

    /// <summary>
    /// Obtiene todos las entidades de muestra.
    /// </summary>
    public Task<IEnumerable<SampleEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IEnumerable<SampleEntity>>(_samples.Where(s => !s.IsDeleted).AsEnumerable());
    }

    /// <summary>
    /// Obtiene una entidad de muestra por su ID.
    /// </summary>
    public Task<SampleEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sample = _samples.FirstOrDefault(s => s.Id == id && !s.IsDeleted);
        return Task.FromResult(sample);
    }

    /// <summary>
    /// Añade una nueva entidad de muestra.
    /// </summary>
    public Task AddAsync(SampleEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _samples.Add(entity);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Actualiza una entidad de muestra existente.
    /// </summary>
    public Task UpdateAsync(SampleEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        var existing = _samples.FirstOrDefault(s => s.Id == entity.Id);
        if (existing == null)
            throw new InvalidOperationException($"Entidad con ID {entity.Id} no encontrada.");

        var index = _samples.IndexOf(existing);
        _samples[index] = entity;
        return Task.CompletedTask;
    }

    /// <summary>
    /// Elimina logicamente una entidad de muestra.
    /// </summary>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sample = _samples.FirstOrDefault(s => s.Id == id && !s.IsDeleted);
        if (sample == null)
            throw new InvalidOperationException($"Entidad con ID {id} no encontrada.");

        // Realiza una eliminación lógica seteando IsDeleted
        // En una implementación real, esto se haría a través de una query de update
        return Task.CompletedTask;
    }
}
