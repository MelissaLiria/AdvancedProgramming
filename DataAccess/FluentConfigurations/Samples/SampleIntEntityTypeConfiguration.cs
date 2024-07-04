using DataAccess.FluentConfigurations.Common;
using Domain.Entities.HistoricalData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.FluentConfigurations.Samples
{
    public class SampleIntEntityTypeConfiguration :
        EntityTypeConfigurationBase<SampleInt>
    {
        public override void Configure(EntityTypeBuilder<SampleInt> builder)
        {
            builder.ToTable("SampleInts");
            builder.HasBaseType(typeof(Sample));

        }
    }
}
