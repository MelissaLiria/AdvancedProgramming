using DataAccess.FluentConfigurations.Common;
using Domain.Entities.HistoricalData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.FluentConfigurations.Samples
{
    public class SampleEntityTypeConfigurationBase :
        IEntityTypeConfiguration<Sample>
    {
        public void Configure(EntityTypeBuilder<Sample> builder)
        {
            builder.HasKey(nameof(Sample.VariableId),nameof(Sample.DateTime));
            builder.Property(x => x.VariableId).IsRequired();
            builder.Property(x => x.DateTime).IsRequired();
            builder.ToTable("Samples");
            builder.HasDiscriminator<string>("DataType")
                .HasValue<SampleBool>("Bool")
                .HasValue<SampleInt>("Int")
                .HasValue<SampleDouble>("Double");
            
        }
    }
}
