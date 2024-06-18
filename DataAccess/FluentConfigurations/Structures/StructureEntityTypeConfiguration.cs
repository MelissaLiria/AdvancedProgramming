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
    public class StructureEntityTypeConfiguration
        :EntityTypeConfigurationBase<Structure>
    {
        public override void Configure(EntityTypeBuilder<Structure> builder)
        {
            base.Configure(builder);
            builder.ToTable("Structure");
        }
    }
}
