using Lab13_HenryVentura.Application;
using Lab13_HenryVentura.Infrastructure.Configuration;
using MediatR;
using Microsoft.OpenApi.Models;

namespace Lab13_HenryVentura.Configuration;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        // Infrastructure
        services.AddInfrastructureServices(configuration);

        // MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            typeof(ApplicationAssemblyMarker).Assembly));

        // Controllers
        services.AddControllers();

        // Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Lab13 HenryVentura API",
                Version = "v1",
                Description = "API con ClosedXML y Arquitectura Hexagonal"
            });
        });

        return services;
    }
}