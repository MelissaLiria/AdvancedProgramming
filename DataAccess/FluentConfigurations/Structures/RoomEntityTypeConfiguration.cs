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
	public class RoomEntityTypeConfiguration : EntityTypeConfigurationBase<Room>
	{
		public override void Configure(EntityTypeBuilder<Room> builder)
		{
			builder.ToTable("Rooms");
			builder.HasBaseType(typeof(Structure));
			builder.HasOne(x => x.Floor).WithMany(x => x.Rooms).HasForeignKey(x => x.FloorId);

		}
	}

}
