namespace Turning.Domain.Exceptions;

/// <summary>
/// Excepción base para errores del dominio.
/// Se utiliza para representar violaciones de las reglas de negocio.
/// </summary>
public class DomainException : Exception
{
    /// <summary>
    /// Constructor de excepción de dominio.
    /// </summary>
    /// <param name="message">Mensaje que describe el error de negocio.</param>
    public DomainException(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor de excepción de dominio con excepción interna.
    /// </summary>
    /// <param name="message">Mensaje que describe el error de negocio.</param>
    /// <param name="innerException">Excepción interna.</param>
    public DomainException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }
}
