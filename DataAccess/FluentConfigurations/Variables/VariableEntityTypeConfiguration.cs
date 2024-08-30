using DataAccess.FluentConfigurations.Common;
using Domain.Entities.ConfigurationData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.FluentConfigurations.Variables
{
    public class VariableEntityTypeConfiguration
        : EntityTypeConfigurationBase<Variable>
    {
        public override void Configure(EntityTypeBuilder<Variable> builder)
        {
            builder.ToTable("Variables");
            //builder.Ignore(x => x.Location);
            builder.HasOne(x => x.Location)
                .WithMany(x => x.Variables)
                .HasForeignKey(x => x.LocationId);
            builder.OwnsOne(x => x.VariableType);
            base.Configure(builder);
        }
    }
}
