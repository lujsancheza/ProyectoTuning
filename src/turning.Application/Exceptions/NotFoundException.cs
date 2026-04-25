namespace Turning.Application.Exceptions;

/// <summary>
/// Excepción que se lanza cuando no se encuentra un recurso solicitado.
/// </summary>
public class NotFoundException : ApplicationException
{
    /// <summary>
    /// Constructor de excepción de recurso no encontrado.
    /// </summary>
    /// <param name="entityName">Nombre de la entidad que no se encontró.</param>
    /// <param name="key">Valor clave que se buscó.</param>
    public NotFoundException(string entityName, string key)
        : base($"La entidad '{entityName}' con clave '{key}' no fue encontrada.", "RESOURCE_NOT_FOUND")
    {
    }
}
