using DataAccess.FluentConfigurations.Common;
using Domain.Entities.ConfigurationData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.FluentConfigurations.Structures
{
    public class FloorEntityTypeConfiguration
        : EntityTypeConfigurationBase<Floor>
    {
        public override void Configure(EntityTypeBuilder<Floor> builder)
        {
            builder.ToTable("Floors");
            builder.HasBaseType(typeof(Structure));
            builder.Ignore(x =>x.Rooms);
            builder.Ignore(x =>x.Variables);
            builder.HasMany(x => x.Rooms).WithOne().HasForeignKey(x => x.RoomId);
            builder.HasMany(x => x.Variables).WithOne().HasForeignKey(x => x.LocationId);

        }
    }
}
