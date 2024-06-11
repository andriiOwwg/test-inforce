using Inforce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace test_inforce_test_1.Extensions;

public static class ProgramExtensions
{
    public static void AddDbAndIdentity(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DbConnection");
            
        services.AddDbContext<PlatformDbContext>(options =>
            options.UseSqlite(connectionString,
                x => x.MigrationsAssembly("Inforce.Persistence")));
    }
}