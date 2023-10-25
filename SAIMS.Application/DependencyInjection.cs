using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SAIMS.Application.Interfaces;
using SAIMS.Application.Models;
using SAIMS.Application.Services;

namespace SAIMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<ISalesService, SalesService>();
        services.AddSingleton<IInventoryService, InvertoryService>();
        services.AddSingleton<IDiscountService, DiscountService>(); 
        

        // configure DI for application services
        services.AddScoped<IJwtUtilsService, JwtUtilsService>();
        return services;
    }
}

