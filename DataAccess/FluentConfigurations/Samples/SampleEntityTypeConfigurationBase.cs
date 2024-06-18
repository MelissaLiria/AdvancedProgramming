using DataAccess.FluentConfigurations.Common;
using Domain.Entities.HistoricalData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.FluentConfigurations.Samples
{
    public class SampleEntityTypeConfigurationBase : EntityTypeConfigurationBase<Sample>
    {
        public override void Configure(EntityTypeBuilder<Sample> builder)
        {
            builder.ToTable("Samples");
            builder.Ignore(x => x.Variable);
            builder.HasOne(x => x.Variable).WithMany().HasForeignKey(x => x.VariableId);
            base.Configure(builder);

        }
    }
}
