using Microsoft.Extensions.DependencyInjection;
using SAIMS.Application.Interfaces;
using SAIMS.Infrastructure.DataAccess;

namespace SAIMS.Infrastructure;

public static class InfrastructureDependencyInjectionSetup
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
        return services;
    }

    public static IServiceCollection AddRepositoriesWithInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ISalesRepository, SalesRepository>();
        services.AddSingleton<IInventoryRepository, InventoryRepository>();
        services.AddSingleton<IDiscountRepository, DiscountRepository>();
        return services;
    }
}