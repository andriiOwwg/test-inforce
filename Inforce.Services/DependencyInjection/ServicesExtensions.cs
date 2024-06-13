using Inforce.Services.Interface;
using Inforce.Services.Services;

namespace Inforce.Services.DependencyInjection;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUrlService, UrlService>();
        services.AddScoped<IUserService, UserService>();
        
        return services;
    }
}