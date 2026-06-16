using Lab13_HenryVentura.Domain.Ports;
using Lab13_HenryVentura.Infrastructure.Adapters;
using Lab13_HenryVentura.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab13_HenryVentura.Infrastructure.Configuration;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        // Fix DateTime PostgreSQL
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        // DbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        // Repositories
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        // UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Excel Service
        services.AddScoped<IExcelService, ExcelService>();

        return services;
    }
}