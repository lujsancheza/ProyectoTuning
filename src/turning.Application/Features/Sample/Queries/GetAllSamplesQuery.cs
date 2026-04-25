using Turning.Application.DTOs;

namespace Turning.Application.Features.Sample.Queries;

/// <summary>
/// Query para obtener todas las entidades de muestra.
/// </summary>
public class GetAllSamplesQuery
{
    /// <summary>
    /// Obtiene o establece un filtro de búsqueda opcional.
    /// </summary>
    public string? SearchTerm { get; set; }

    /// <summary>
    /// Obtiene o establece si incluir solo entidades activas.
    /// </summary>
    public bool OnlyActive { get; set; } = true;
}

/// <summary>
/// Respuesta para la query de obtener todos las muestras.
/// </summary>
public class GetAllSamplesResponse
{
    /// <summary>
    /// Lista de entidades de muestra.
    /// </summary>
    public IEnumerable<SampleDto> Samples { get; set; } = [];

    /// <summary>
    /// Total de entidades encontradas.
    /// </summary>
    public int Total { get; set; }
}
