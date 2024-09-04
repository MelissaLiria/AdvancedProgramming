using DataAccess.FluentConfigurations.Common;
using Domain.Entities.ConfigurationData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.FluentConfigurations.Structures
{
    public class BuildingEntityTypeConfiguration
        : EntityTypeConfigurationBase<Building>
    {
        public override void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.ToTable("Buildings");
            builder.HasBaseType(typeof(Structure));
            builder.HasMany(x => x.Floors)
                .WithOne(x => x.Building)
                .HasForeignKey(x => x.BuildingId);
                


        }
    }
}
