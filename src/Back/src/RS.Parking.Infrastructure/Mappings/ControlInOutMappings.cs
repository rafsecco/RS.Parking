using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure.Mappings;

internal class ControlInOutMappings : IEntityTypeConfiguration<ControlInOut>
{
	public void Configure(EntityTypeBuilder<ControlInOut> builder)
	{
		builder.ToTable("tb_ControlInOut")
			.HasKey(k => k.Id);
		//.HasKey(cio => new { cio.VehicleTypeId, cio.AccordTypeId });

		builder.Property(p => p.Id)
			.HasColumnName("id_controlInOut")
			.HasColumnType("BIGINT UNSIGNED")
			.ValueGeneratedOnAdd();

		builder.Property(p => p.VehicleTypeId)
			.IsRequired()
			.HasColumnName("cd_vehicle")
			.HasColumnType("TINYINT UNSIGNED");

		builder.Property(p => p.AccordTypeId)
			.IsRequired()
			.HasColumnName("cd_accord")
			.HasColumnType("TINYINT UNSIGNED");

		builder.Property(p => p.DateTimeIn)
			.IsRequired()
			.HasColumnName("dt_in")
			.HasDefaultValueSql("NOW()");

		builder.Property(p => p.DateTimeOut)
			.IsRequired(false)
			.HasColumnName("dt_out");

		builder.Property(p => p.LicensePlate)
			.IsRequired()
			.HasColumnName("ds_licensePlate")
			.HasMaxLength(7);

		builder.HasIndex(i => i.DateTimeOut, "idx_tb_ControleInOut_dt_out");
		//.IsUnique();

		//builder.Ignore(i => new { i.AccordType, i.VehicleType });
		builder.Ignore(i => i.AccordType);
		builder.Ignore(i => i.VehicleType);


		#region Owned Types
		//builder.OwnsOne(v => v.VehicleType);
		//builder.OwnsOne(a => a.AccordType);

		//builder.HasOne("RS.Parking.Domain.Models.AccordType", "AccordType")
		//	.WithOne()
		//	.IsRequired(false)
		//	.HasForeignKey("FK_tb_ControleInOut_tb_AccordType-AccordTypeId");

		//builder.HasOne("RS.Parking.Domain.Models.VehicleType", "VehicleType")
		//	.WithOne()
		//	.IsRequired()
		//	.HasForeignKey("FK_tb_ControleInOut_tb_VehicleType-VehicleTypeId");
		#endregion

		#region Populate
		ControlInOut[] objControlInOut =
		{
		 	new ControlInOut {
				Id=1,
				VehicleTypeId=1,
				AccordTypeId=1,
				DateTimeIn=DateTime.Now.Date.AddDays(-1).AddHours(8).AddMinutes(0),
				DateTimeOut=DateTime.Now.Date.AddDays(-1).AddHours(10).AddMinutes(0),
				LicensePlate="BRL-123",
			 },
		 	new ControlInOut {
				Id=2,
				VehicleTypeId=1,
				AccordTypeId=2,
				DateTimeIn=DateTime.Now.Date.AddDays(-1).AddHours(10).AddMinutes(0),
				DateTimeOut=DateTime.Now.Date.AddDays(-1).AddHours(12).AddMinutes(30),
				LicensePlate="BRL-456"
			},
			new ControlInOut {
				Id=3,
				VehicleTypeId=1,
				AccordTypeId=3,
				DateTimeIn=DateTime.Now.Date.AddDays(-1).AddHours(12).AddMinutes(30),
				DateTimeOut=DateTime.Now.Date.AddDays(-1).AddHours(14).AddMinutes(30),
				LicensePlate="BRL-789"
			},
			new ControlInOut {
				Id=4,
				VehicleTypeId=1,
				AccordTypeId=4,
				DateTimeIn=DateTime.Now.Date.AddDays(-1).AddHours(16).AddMinutes(30),
				DateTimeOut=DateTime.Now.Date.AddDays(-1).AddHours(18).AddMinutes(30),
				LicensePlate="BRL-147"
			},

			new ControlInOut {
				Id=5,
				VehicleTypeId=2,
				AccordTypeId=1,
				DateTimeIn=DateTime.Now.Date.AddDays(-2).AddHours(8).AddMinutes(0),
				DateTimeOut=DateTime.Now.Date.AddDays(-2).AddHours(10).AddMinutes(0),
				LicensePlate="BRL-123",
			 },
		 	new ControlInOut {
				Id=6,
				VehicleTypeId=2,
				AccordTypeId=2,
				DateTimeIn=DateTime.Now.Date.AddDays(-2).AddHours(10).AddMinutes(0),
				DateTimeOut=DateTime.Now.Date.AddDays(-2).AddHours(12).AddMinutes(30),
				LicensePlate="BRL-456"
			},
			new ControlInOut {
				Id=7,
				VehicleTypeId=2,
				AccordTypeId=3,
				DateTimeIn=DateTime.Now.Date.AddDays(-2).AddHours(12).AddMinutes(30),
				DateTimeOut=DateTime.Now.Date.AddDays(-2).AddHours(14).AddMinutes(30),
				LicensePlate="BRL-789"
			},
			new ControlInOut {
				Id=8,
				VehicleTypeId=2,
				AccordTypeId=4,
				DateTimeIn=DateTime.Now.Date.AddDays(-2).AddHours(16).AddMinutes(30),
				DateTimeOut=DateTime.Now.Date.AddDays(-2).AddHours(18).AddMinutes(30),
				LicensePlate="BRL-147"
			},

			new ControlInOut {
				Id=9,
				VehicleTypeId=3,
				AccordTypeId=1,
				DateTimeIn=DateTime.Now.Date.AddDays(-3).AddHours(8).AddMinutes(0),
				DateTimeOut=DateTime.Now.Date.AddDays(-3).AddHours(10).AddMinutes(0),
				LicensePlate="BRL-123",
			 },
		 	new ControlInOut {
				Id=10,
				VehicleTypeId=3,
				AccordTypeId=2,
				DateTimeIn=DateTime.Now.Date.AddDays(-3).AddHours(10).AddMinutes(0),
				DateTimeOut=DateTime.Now.Date.AddDays(-3).AddHours(12).AddMinutes(30),
				LicensePlate="BRL-456"
			},
			new ControlInOut {
				Id=11,
				VehicleTypeId=3,
				AccordTypeId=3,
				DateTimeIn=DateTime.Now.Date.AddDays(-3).AddHours(12).AddMinutes(30),
				DateTimeOut=DateTime.Now.Date.AddDays(-3).AddHours(14).AddMinutes(30),
				LicensePlate="BRL-789"
			},
			new ControlInOut {
				Id=12,
				VehicleTypeId=3,
				AccordTypeId=4,
				DateTimeIn=DateTime.Now.Date.AddDays(-3).AddHours(16).AddMinutes(30),
				DateTimeOut=DateTime.Now.Date.AddDays(-3).AddHours(18).AddMinutes(30),
				LicensePlate="BRL-147"
			},

			new ControlInOut {
				Id=13,
				VehicleTypeId=3,
				AccordTypeId=1,
				DateTimeIn=DateTime.Now.Date.AddHours(8).AddMinutes(0),
				DateTimeOut=null,
				LicensePlate="BRL-123",
			 },
		 	new ControlInOut {
				Id=14,
				VehicleTypeId=3,
				AccordTypeId=2,
				DateTimeIn=DateTime.Now.Date.AddHours(10).AddMinutes(0),
				DateTimeOut=null,
				LicensePlate="BRL-456"
			},
			new ControlInOut {
				Id=15,
				VehicleTypeId=3,
				AccordTypeId=3,
				DateTimeIn=DateTime.Now.Date.AddHours(12).AddMinutes(30),
				DateTimeOut=null,
				LicensePlate="BRL-789"
			},
			new ControlInOut {
				Id=16,
				VehicleTypeId=3,
				AccordTypeId=4,
				DateTimeIn=DateTime.Now.Date.AddHours(16).AddMinutes(30),
				DateTimeOut=null,
				LicensePlate="BRL-147"
			}
		 };
		builder.HasData(objControlInOut);
		#endregion

	}
}
