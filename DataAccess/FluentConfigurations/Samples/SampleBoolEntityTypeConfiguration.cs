using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.FluentConfigurations.Common;
using Domain.Entities.HistoricalData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccess.FluentConfigurations.Samples
{
    public class SampleBoolEntityTypeConfiguration : EntityTypeConfigurationBase<SampleBool>
    {
        public override void Configure(EntityTypeBuilder<SampleBool> builder)
        {
            builder.ToTable("SampleBools");
            builder.HasBaseType(typeof(Sample));

        }
    }
}
