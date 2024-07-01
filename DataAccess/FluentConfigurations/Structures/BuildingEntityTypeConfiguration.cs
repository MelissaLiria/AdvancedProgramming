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
            builder.HasMany(x => x.Floors).WithOne(x => x.Building).HasForeignKey(x => x.BuildingId);

        }
    }
}
