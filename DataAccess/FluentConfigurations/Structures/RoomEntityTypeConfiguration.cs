using DataAccess.FluentConfigurations.Common;
using Domain.Entities.ConfigurationData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.FluentConfigurations.Structures
{
    public class RoomEntityTypeConfiguration 
        : EntityTypeConfigurationBase<Room>
    {
        public override void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");
            builder.Ignore(x => x.Floor);
            builder.HasBaseType(typeof(Structure));
            builder.HasOne(x => x.Floor)
                .WithMany(x => x.Rooms)
                .HasForeignKey(x => x.FloorId);

        }
    }

}
