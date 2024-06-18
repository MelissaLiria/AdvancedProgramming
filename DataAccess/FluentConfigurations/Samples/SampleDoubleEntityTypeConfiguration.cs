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
    public class SampleDoubleEntityTypeConfiguration : EntityTypeConfigurationBase<SampleDouble>
    {
        public override void Configure(EntityTypeBuilder<SampleDouble> builder)
        {
            builder.ToTable("SampleDoubles");
            builder.HasBaseType(typeof(Sample));

        }
    }
}
