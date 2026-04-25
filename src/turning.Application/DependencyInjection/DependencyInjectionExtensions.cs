namespace Turning.Application.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extensiones para registrar servicios de Application en el contenedor de inyección de dependencias.
/// </summary>
public static class DependencyInjectionExtensions
{
    /// <summary>
    /// Añade los servicios de la capa Application al contenedor de servicios.
    /// </summary>
    /// <param name="services">Colección de servicios.</param>
    /// <returns>La colección de servicios para permitir encadenamiento.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Aquí se registrarían los servicios de MediatR, validadores, etc.
        // services.AddMediatR(typeof(DependencyInjectionExtensions).Assembly);
        // services.AddValidatorsFromAssembly(typeof(DependencyInjectionExtensions).Assembly);

        return services;
    }
}
