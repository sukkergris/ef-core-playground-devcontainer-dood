using Agency.Models;
using Microsoft.EntityFrameworkCore;

namespace Agency;

public class AgencyDbContext : DbContext
{
    public const string Schema = "agency";

    public AgencyDbContext(DbContextOptions<AgencyDbContext> options) : base(options)
    {

    }

    public DbSet<Agent> Agents { get; set; }
    public DbSet<Models.Agency> Agencies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);

        modelBuilder.Entity<Agent>().HasIndex(a => a.Id);

        modelBuilder.Entity<Models.Agency>().HasIndex(a => a.Id);

        modelBuilder.Entity<Models.Agency>().HasMany(a => a.Agents);
    }
}
