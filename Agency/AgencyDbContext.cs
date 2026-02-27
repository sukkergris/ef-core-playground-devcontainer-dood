using System.Reflection;
using Agency.Models;
using Microsoft.EntityFrameworkCore;

namespace Agency;

public class AgencyDbContext : DbContext
{
    public AgencyDbContext(DbContextOptions<AgencyDbContext> options) : base(options)
    {

    }

    public DbSet<Agent> Agents { get; set; }
    public DbSet<Models.Agency> Agencies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Globals.AgencyDefaultSchema);

        // Add IEntityTypeConfiguration's (See. the folder EntityConfigurations)
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
   }
}
