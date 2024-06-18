using DataAccess.FluentConfigurations.Common;
using Domain.Entities.ConfigurationData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.FluentConfigurations.Variables
{
    public class VariableEntityTypeConfiguration : EntityTypeConfigurationBase<Variable>
    {
        public override void Configure(EntityTypeBuilder<Variable> builder)
        {
            builder.ToTable("Variables");
            base.Configure(builder);
            builder.Ignore(x => x.Location);
            builder.HasOne(x => x.Location).WithMany().HasForeignKey(x => x.LocationId);
            builder.OwnsOne(x => x.VariableType);
        }
    }
}
