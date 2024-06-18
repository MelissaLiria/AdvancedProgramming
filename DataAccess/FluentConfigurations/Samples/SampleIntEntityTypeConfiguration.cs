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
    public class SampleIntEntityTypeConfiguration : EntityTypeConfigurationBase<SampleInt>
    {
        public override void Configure(EntityTypeBuilder<SampleInt> builder)
        {
            builder.ToTable("SampleInts");
            builder.HasBaseType(typeof(Sample));

        }
    }
}
