using Agency.Models;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Agency.EntityConfigurations;

public class AgencyConfiguration : IEntityTypeConfiguration<Models.Agency>
{
    public void Configure(EntityTypeBuilder<Models.Agency> builder)
    {
        builder.ToTable(typeof(Models.Agency).Name.Pluralize());
        builder.HasKey(a=>a.Id);
        builder.HasMany(a => a.Agents);
    }
}
