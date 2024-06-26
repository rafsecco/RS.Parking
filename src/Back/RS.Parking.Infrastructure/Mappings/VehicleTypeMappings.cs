using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure.Mappings;

internal class VehicleTypeMappings : IEntityTypeConfiguration<VehicleType>
{
	public void Configure(EntityTypeBuilder<VehicleType> builder)
	{
		builder.ToTable("tb_VehicleType")
			.HasKey(k => k.Id);

		builder.Property(p => p.Id)
			.HasColumnName("id_vehicle")
			.HasColumnType("TINYINT UNSIGNED")  //System.Byte 
			.ValueGeneratedOnAdd();

		builder.Property(p => p.Active)
			.IsRequired()
			.HasColumnName("bln_active");

		builder.Property(p => p.DateCreated)
			.IsRequired()
			.HasColumnName("dt_dateCreated")
			.HasDefaultValueSql("UTC_TIMESTAMP()");

		builder.Property(p => p.Cost)
			.IsRequired()
			//.IsConcurrencyToken()
			.HasColumnName("vl_cost")
			.HasPrecision(15, 2);

		builder.Property(p => p.Description)
			.IsRequired()
			.HasColumnName("ds_vehicle")
			.HasMaxLength(100);

		//builder.Ignore(i => i.ControlInOut);

		#region Populate
		//VehicleType[] objVehicleType = {
		//	new VehicleType {Id=1, Active=true, Cost=4m, Description="Car 1 (small)" },
		//	new VehicleType {Id=2, Active=true, Cost=5.5m, Description="Car 2 (big)" },
		//	new VehicleType {Id=3, Active=true, Cost=3m, Description="Moto 1" },
		//};
		//builder.HasData(objVehicleType);
		#endregion
	}
}
