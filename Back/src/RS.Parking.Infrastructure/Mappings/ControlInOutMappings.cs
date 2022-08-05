//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using RS.Parking.Domain.Models;

//namespace RS.Parking.Infrastructure.Mappings;

//internal class ControlInOutMappings : IEntityTypeConfiguration<ControlInOut>
//{
//	public void Configure(EntityTypeBuilder<ControlInOut> builder)
//	{
//		builder.ToTable("tb_ControleInOut")
//			.HasKey(k => k.Id);

//		builder.Property(p => p.Id)
//			.HasColumnName("id_controleInOut")
//			.HasColumnType("BIGINT UNSIGNED")
//			.ValueGeneratedOnAdd();

//		builder.Property(p => p.LicensePlate)
//			.IsRequired()
//			.HasColumnName("ds_licensePlate")
//			.HasColumnType("VARCHAR(7)");

//		builder.Property(p => p.DateTimeIn)
//			.IsRequired()
//			.HasColumnName("dt_in")
//			.HasDefaultValueSql("NOW()");

//		builder.Property(p => p.DateTimeOut)
//			.HasColumnName("dt_out");


//		builder.Property(p => p.VehicleType.Id)
//			.IsRequired()
//			.HasColumnName("cd_vehicle")
//			.HasColumnType("TINYINT UNSIGNED");

//		builder.Property(p => p.AccordType.Id)
//			.IsRequired()
//			.HasColumnName("cd_accord")
//			.HasColumnType("TINYINT UNSIGNED");


//		builder.HasIndex(i => i.DateTimeIn, "idx_tb_ControleInOut_dt_in");
//		//.IsUnique();

//		builder.Ignore(i => new { i.AccordType, i.VehicleType });

//		// 1 : 1 => ControlInOut : VehicleType
//		//builder
//		//	.HasOne(p => p.VehicleType)
//		//	.WithOne(p => p.ControlInOut);

//		// 1 : 1 => ControlInOut : AccordType
//		//builder
//		//	.HasOne(p => p.AccordType)
//		//	.WithOne(p => p.ControlInOut);

//		#region Owned Types
//		//modelBuilder.Entity<ControlInOut>(p => 
//		//{ 
//		//	p.OwnsOne(x => x.VehicleType); 
//		//});

//		//modelBuilder.Entity<ControlInOut>(p =>
//		//{
//		//	p.OwnsOne(x => x.AccordType);
//		//});
//		#endregion
//	}
//}

