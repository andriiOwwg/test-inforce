using Inforce.Persistence.Contexts.Configurations;
using Inforce.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Inforce.Persistence.Contexts;

public class PlatformDbContext: IdentityDbContext<IdentityUser>
{
    public PlatformDbContext(DbContextOptions<PlatformDbContext> options) : base(options)
    {
    }
    
   /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=db_context.db");
    }*/

    public DbSet<User> Users { get; set; }
    
    public DbSet<Url> Urls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UrlConfiguration());
    }
    
    public class YourDbContextFactory : IDesignTimeDbContextFactory<PlatformDbContext>
    {
        public PlatformDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PlatformDbContext>();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "Inforce.Core"))
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DbConnection");
            optionsBuilder.UseSqlite(connectionString);

            return new PlatformDbContext(optionsBuilder.Options);
        }
    }
}