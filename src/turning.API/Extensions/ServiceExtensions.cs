namespace Turning.API.Extensions;

/// <summary>
/// Extensiones para configuración de la API.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Añade configuraciones de CORS a la aplicación.
    /// </summary>
    /// <param name="services">Colección de servicios.</param>
    /// <returns>La colección de servicios para encadenamiento.</returns>
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            options.AddPolicy("AllowSpecific", builder =>
            {
                builder
                    .WithOrigins("https://localhost:3000", "https://localhost:7001")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });

        return services;
    }

    /// <summary>
    /// Configura la compresión de respuestas.
    /// </summary>
    /// <param name="services">Colección de servicios.</param>
    /// <returns>La colección de servicios para encadenamiento.</returns>
    public static IServiceCollection AddCompressionConfiguration(this IServiceCollection services)
    {
        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
        });

        return services;
    }
}
