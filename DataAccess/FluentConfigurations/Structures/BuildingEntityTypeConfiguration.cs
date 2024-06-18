using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.ConfigurationData;

namespace DataAccess.FluentConfigurations.Structures
{
    public class BuildingEntityTypeConfiguration
        : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.ToTable("Buildings");
            builder.HasBaseType(typeof(Structure));
            builder.Ignore(x => x.Floors);
            builder.Ignore(x => x.Variables);
            builder.HasMany(x => x.Floors).WithOne().HasForeignKey(x => x.BuildingId);
            builder.HasMany(x => x.Variables).WithOne().HasForeignKey(x => x.LocationId);
        }
    }
}
