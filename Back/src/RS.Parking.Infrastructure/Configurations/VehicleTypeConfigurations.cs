//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using RS.Parking.Domain.Models;

//namespace RS.Parking.Infrastructure.Configurations;

//internal class VehicleTypeConfigurations : IEntityTypeConfiguration<VehicleType>
//{
//	public void Configure(EntityTypeBuilder<VehicleType> builder)
//	{
//		builder.ToTable("tb_VehicleType")
//			.HasKey(k => k.Id);

//		builder.Property(p => p.Id)
//			.HasColumnName("id_vehicle")
//			.HasColumnType("TINYINT UNSIGNED")  //System.Byte 
//			.ValueGeneratedOnAdd();

//		builder.Property(p => p.Description)
//			.IsRequired()
//			.HasColumnName("ds_vehicle")
//			.HasColumnType("VARCHAR(100)");

//		builder.Property(p => p.Cost)
//			.IsRequired()
//			.HasColumnName("vl_cost")
//			.HasColumnType("DECIMAL")
//			.HasPrecision(15, 2);

//		builder.Property(p => p.Active)
//			.IsRequired()
//			.HasColumnName("bln_active")
//			.HasColumnType("BOOLEAN");

//		builder.Property(p => p.DateCreated)
//			.IsRequired()
//			.HasColumnName("dt_dateCreated")
//			.HasDefaultValueSql("NOW()");

//		//builder.HasData(new[] {
//		//	new VehicleType ("Car One", 5.5m),
//		//	new VehicleType ("Car Two", 10.5m),
//		//});

//	}
//}
