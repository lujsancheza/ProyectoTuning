using Microsoft.Extensions.DependencyInjection;
using Turning.Application.Interfaces;
using Turning.Infrastructure.Repositories;

namespace Turning.Infrastructure.DependencyInjection;

/// <summary>
/// Extensiones para registrar servicios de Infrastructure en el contenedor de inyección de dependencias.
/// </summary>
public static class DependencyInjectionExtensions
{
    /// <summary>
    /// Añade los servicios de la capa Infrastructure al contenedor de servicios.
    /// </summary>
    /// <param name="services">Colección de servicios.</param>
    /// <returns>La colección de servicios para permitir encadenamiento.</returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // Registra los repositorios
        // IMPORTANTE: En producción, reemplaza InMemorySampleRepository con una implementación real
        services.AddScoped<ISampleRepository, InMemorySampleRepository>();

        // Aquí se registrarían otros servicios de infraestructura:
        // - DbContext
        // - Unit of Work
        // - External API clients
        // - Email services
        // - etc.

        return services;
    }
}
