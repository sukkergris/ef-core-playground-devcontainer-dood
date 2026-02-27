using Agency.Models;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agency.EntityConfigurations;

public class AgentConfiguration : IEntityTypeConfiguration<Agent>
{
    public void Configure(EntityTypeBuilder<Agent> builder)
    {
        builder.ToTable(typeof(Agent).Name.Pluralize());
        builder.HasKey(a => a.Id);
    }
}
