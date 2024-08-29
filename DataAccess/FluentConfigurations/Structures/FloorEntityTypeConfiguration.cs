using DataAccess.FluentConfigurations.Common;
using Domain.Entities.ConfigurationData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.FluentConfigurations.Structures
{
    public class FloorEntityTypeConfiguration
        : EntityTypeConfigurationBase<Floor>
    {
        public override void Configure(EntityTypeBuilder<Floor> builder)
        {
            builder.ToTable("Floors");
            builder.Ignore(x => x.Building);
            builder.HasBaseType(typeof(Structure));
            builder.HasMany(x => x.Rooms)
                .WithOne(x => x.Floor)
                .HasForeignKey(x => x.FloorId);

        }
    }
}
