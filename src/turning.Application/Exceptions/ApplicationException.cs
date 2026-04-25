namespace Turning.Application.Exceptions;

/// <summary>
/// Excepción de aplicación base para errores de la capa de aplicación.
/// </summary>
public class ApplicationException : Exception
{
    /// <summary>
    /// Constructor de excepción de aplicación.
    /// </summary>
    /// <param name="message">Mensaje que describe el error.</param>
    public ApplicationException(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor de excepción de aplicación con código de error.
    /// </summary>
    /// <param name="message">Mensaje que describe el error.</param>
    /// <param name="code">Código de error único.</param>
    public ApplicationException(string message, string code) : base(message)
    {
        Code = code;
    }

    /// <summary>
    /// Código de error único para identificar el tipo de error.
    /// </summary>
    public string? Code { get; set; }
}
