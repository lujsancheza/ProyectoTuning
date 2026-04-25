using Turning.Application.DTOs;

namespace Turning.Application.Features.Sample.Queries;

/// <summary>
/// Query para obtener una entidad de muestra por su ID.
/// </summary>
public class GetSampleByIdQuery
{
    /// <summary>
    /// Identificador de la entidad a obtener.
    /// </summary>
    public Guid Id { get; set; }
}

/// <summary>
/// Respuesta para la query de obtener muestra por ID.
/// </summary>
public class GetSampleByIdResponse
{
    /// <summary>
    /// Datos de la entidad de muestra.
    /// </summary>
    public SampleDto? Sample { get; set; }
}
