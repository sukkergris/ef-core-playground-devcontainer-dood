using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Agency;
/// <summary>
/// Design-time factory for library-only setups.
/// Keeps the DbContext independent of a startup project and is used by EF during migrations.
/// </summary>
public class AgencyDbContextFactory : IDesignTimeDbContextFactory<AgencyDbContext>
{
    public AgencyDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<AgencyDbContext>();
        optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

        return new AgencyDbContext(optionsBuilder.Options);
    }
}
