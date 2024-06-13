using WebApplication1.Interfaces;
using WebApplication1.Repositories;

namespace Inforce.Persistence.DependencyInjection;

public static class RepositoriesExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IUrlRepository, UrlRepository>(); 
        return serviceCollection;
    }
}