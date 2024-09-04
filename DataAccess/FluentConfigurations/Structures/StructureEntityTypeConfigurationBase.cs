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
    public class StructureEntityTypeConfigurationBase
        :EntityTypeConfigurationBase<Structure>
    {
        public override void Configure(EntityTypeBuilder<Structure> builder)
        {
            builder.ToTable("Structure");
            builder.HasMany(x => x.Variables)
                .WithOne(x => x.Location)
                .HasForeignKey(x => x.LocationId);
            base.Configure(builder);
            
        }
    }
}
