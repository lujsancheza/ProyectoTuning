using Turning.Application.DTOs;

namespace Turning.Application.Features.Sample.Commands;

/// <summary>
/// Comando para crear una nueva entidad de muestra.
/// </summary>
public class CreateSampleCommand
{
    /// <summary>
    /// Nombre de la entidad a crear.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Descripción opcional de la entidad.
    /// </summary>
    public string? Description { get; set; }
}

/// <summary>
/// Respuesta del comando crear muestra.
/// </summary>
public class CreateSampleResponse
{
    /// <summary>
    /// Identificador de la entidad creada.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Datos completos de la entidad creada.
    /// </summary>
    public SampleDto? Sample { get; set; }

    /// <summary>
    /// Mensaje de éxito.
    /// </summary>
    public string Message { get; set; } = "Entidad creada exitosamente.";
}
