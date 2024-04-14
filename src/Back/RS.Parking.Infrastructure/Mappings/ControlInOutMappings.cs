using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure.Mappings;

internal class ControlInOutMappings : IEntityTypeConfiguration<ControlInOut>
{
	public void Configure(EntityTypeBuilder<ControlInOut> builder)
	{
		builder.ToTable("tb_ControlInOut")
			.HasKey(k => k.Id);

		builder.Property(p => p.Id)
			.IsRequired()
			.HasColumnOrder(1)
			.HasColumnName("id_controlInOut")
			.HasColumnType("BIGINT UNSIGNED")
			.ValueGeneratedOnAdd();

		builder.Property(p => p.VehicleTypeId)
			.IsRequired()
			.HasColumnOrder(2)
			.HasColumnName("cd_vehicle")
			.HasColumnType("TINYINT UNSIGNED");

		builder.Property(p => p.AccordTypeId)
			.IsRequired()
			.HasColumnOrder(3)
			.HasDefaultValue(0)
			.HasColumnName("cd_accord")
			.HasColumnType("TINYINT UNSIGNED");

		builder.Property(p => p.DateTimeIn)
			.IsRequired()
			.HasColumnOrder(4)
			.HasColumnName("dt_in")
			.HasDefaultValueSql("NOW()");

		builder.Property(p => p.DateTimeOut)
			.IsRequired(false)
			.HasColumnOrder(5)
			.HasColumnName("dt_out");

		builder.Property(p => p.LicensePlate)
			.IsRequired()
			.HasColumnOrder(6)
			.HasColumnName("ds_licensePlate")
			.HasColumnType("varchar(7)")
			.HasMaxLength(7);

		builder.HasIndex(i => new { i.DateTimeIn, i.DateTimeOut }, "idx_tb_ControleInOut-dt_in_dt_out");

		//builder.Ignore(i => new { i.AccordType, i.VehicleType });
		//builder.Ignore(i => i.AccordType);
		//builder.Ignore(i => i.VehicleType);

		#region EF Relation
		// 1 : 1 => ControlInOut : VehicleType
		//builder
		//	.HasOne(c => c.VehicleType)
		//	.WithOne(v => v.ControlInOut);
			//.HasForeignKey<ControlInOut>(fk => fk.VehicleTypeId);
		//.HasConstraintName("FK_tb_ControleInOut_tb_VehicleType-VehicleTypeId");


		// 1 : 1 => ControlInOut : AccordType
		//builder
		//	.HasOne(c => c.AccordType)
		//	.WithOne(v => v.ControlInOut);
		//	.HasForeignKey<ControlInOut>(fk => fk.AccordTypeId)
		//	.HasConstraintName("FK_tb_ControleInOut_tb_AccordType-AccordTypeId")
		//	.IsRequired();
		#endregion

		#region Populate
		//ControlInOut[] objControlInOut =
		//{
		// 	new ControlInOut {
		//		Id=1,
		//		VehicleTypeId=1,
		//		AccordTypeId=1,
		//		DateTimeIn=DateTime.Now.Date.AddDays(-1).AddHours(8).AddMinutes(0),
		//		DateTimeOut=DateTime.Now.Date.AddDays(-1).AddHours(10).AddMinutes(0),
		//		LicensePlate="BRL-123",
		//	 },
		// 	new ControlInOut {
		//		Id=2,
		//		VehicleTypeId=1,
		//		AccordTypeId=2,
		//		DateTimeIn=DateTime.Now.Date.AddDays(-1).AddHours(10).AddMinutes(0),
		//		DateTimeOut=DateTime.Now.Date.AddDays(-1).AddHours(12).AddMinutes(30),
		//		LicensePlate="BRL-456"
		//	},
		//	new ControlInOut {
		//		Id=3,
		//		VehicleTypeId=1,
		//		AccordTypeId=3,
		//		DateTimeIn=DateTime.Now.Date.AddDays(-1).AddHours(12).AddMinutes(30),
		//		DateTimeOut=DateTime.Now.Date.AddDays(-1).AddHours(14).AddMinutes(30),
		//		LicensePlate="BRL-789"
		//	},
		//	new ControlInOut {
		//		Id=4,
		//		VehicleTypeId=1,
		//		AccordTypeId=4,
		//		DateTimeIn=DateTime.Now.Date.AddDays(-1).AddHours(16).AddMinutes(30),
		//		DateTimeOut=DateTime.Now.Date.AddDays(-1).AddHours(18).AddMinutes(30),
		//		LicensePlate="BRL-147"
		//	},

		//	new ControlInOut {
		//		Id=5,
		//		VehicleTypeId=2,
		//		AccordTypeId=1,
		//		DateTimeIn=DateTime.Now.Date.AddDays(-2).AddHours(8).AddMinutes(0),
		//		DateTimeOut=DateTime.Now.Date.AddDays(-2).AddHours(10).AddMinutes(0),
		//		LicensePlate="BRL-123",
		//	 },
		// 	new ControlInOut {
		//		Id=6,
		//		VehicleTypeId=2,
		//		AccordTypeId=2,
		//		DateTimeIn=DateTime.Now.Date.AddDays(-2).AddHours(10).AddMinutes(0),
		//		DateTimeOut=DateTime.Now.Date.AddDays(-2).AddHours(12).AddMinutes(30),
		//		LicensePlate="BRL-456"
		//	},
		//	new ControlInOut {
		//		Id=7,
		//		VehicleTypeId=2,
		//		AccordTypeId=3,
		//		DateTimeIn=DateTime.Now.Date.AddDays(-2).AddHours(12).AddMinutes(30),
		//		DateTimeOut=DateTime.Now.Date.AddDays(-2).AddHours(14).AddMinutes(30),
		//		LicensePlate="BRL-789"
		//	},
		//	new ControlInOut {
		//		Id=8,
		//		VehicleTypeId=2,
		//		AccordTypeId=4,
		//		DateTimeIn=DateTime.Now.Date.AddDays(-2).AddHours(16).AddMinutes(30),
		//		DateTimeOut=DateTime.Now.Date.AddDays(-2).AddHours(18).AddMinutes(30),
		//		LicensePlate="BRL-147"
		//	},

		//	new ControlInOut {
		//		Id=9,
		//		VehicleTypeId=3,
		//		AccordTypeId=1,
		//		DateTimeIn=DateTime.Now.Date.AddDays(-3).AddHours(8).AddMinutes(0),
		//		DateTimeOut=DateTime.Now.Date.AddDays(-3).AddHours(10).AddMinutes(0),
		//		LicensePlate="BRL-123",
		//	 },
		// 	new ControlInOut {
		//		Id=10,
		//		VehicleTypeId=3,
		//		AccordTypeId=2,
		//		DateTimeIn=DateTime.Now.Date.AddDays(-3).AddHours(10).AddMinutes(0),
		//		DateTimeOut=DateTime.Now.Date.AddDays(-3).AddHours(12).AddMinutes(30),
		//		LicensePlate="BRL-456"
		//	},
		//	new ControlInOut {
		//		Id=11,
		//		VehicleTypeId=3,
		//		AccordTypeId=3,
		//		DateTimeIn=DateTime.Now.Date.AddDays(-3).AddHours(12).AddMinutes(30),
		//		DateTimeOut=DateTime.Now.Date.AddDays(-3).AddHours(14).AddMinutes(30),
		//		LicensePlate="BRL-789"
		//	},
		//	new ControlInOut {
		//		Id=12,
		//		VehicleTypeId=3,
		//		AccordTypeId=4,
		//		DateTimeIn=DateTime.Now.Date.AddDays(-3).AddHours(16).AddMinutes(30),
		//		DateTimeOut=DateTime.Now.Date.AddDays(-3).AddHours(18).AddMinutes(30),
		//		LicensePlate="BRL-147"
		//	},

		//	new ControlInOut {
		//		Id=13,
		//		VehicleTypeId=1,
		//		AccordTypeId=1,
		//		DateTimeIn=DateTime.Now.Date.AddHours(8).AddMinutes(0),
		//		DateTimeOut=null,
		//		LicensePlate="BRL-123",
		//	 },
		// 	new ControlInOut {
		//		Id=14,
		//		VehicleTypeId=2,
		//		AccordTypeId=2,
		//		DateTimeIn=DateTime.Now.Date.AddHours(10).AddMinutes(0),
		//		DateTimeOut=null,
		//		LicensePlate="BRL-456"
		//	},
		//	new ControlInOut {
		//		Id=15,
		//		VehicleTypeId=3,
		//		AccordTypeId=3,
		//		DateTimeIn=DateTime.Now.Date.AddHours(12).AddMinutes(30),
		//		DateTimeOut=null,
		//		LicensePlate="BRL-789"
		//	},
		//	new ControlInOut {
		//		Id=16,
		//		VehicleTypeId=1,
		//		AccordTypeId=4,
		//		DateTimeIn=DateTime.Now.Date.AddHours(16).AddMinutes(30),
		//		DateTimeOut=null,
		//		LicensePlate="BRL-147"
		//	},
		//	new ControlInOut {
		//		Id=17,
		//		VehicleTypeId=2,
		//		AccordTypeId=1,
		//		DateTimeIn=DateTime.Now.Date.AddHours(18).AddMinutes(0),
		//		DateTimeOut=null,
		//		LicensePlate="BRL-753"
		//	},
		//	new ControlInOut {
		//		Id=18,
		//		VehicleTypeId=2,
		//		AccordTypeId=3,
		//		DateTimeIn=DateTime.Now.Date.AddHours(19).AddMinutes(30),
		//		DateTimeOut=null,
		//		LicensePlate="BRL-321"
		//	},
		//	new ControlInOut {
		//		Id=19,
		//		VehicleTypeId=2,
		//		AccordTypeId=4,
		//		DateTimeIn=DateTime.Now.Date.AddHours(20).AddMinutes(0),
		//		DateTimeOut=null,
		//		LicensePlate="BRL-654"
		//	},
		//	new ControlInOut {
		//		Id=20,
		//		VehicleTypeId=3,
		//		AccordTypeId=1,
		//		DateTimeIn=DateTime.Now.Date.AddHours(21).AddMinutes(30),
		//		DateTimeOut=null,
		//		LicensePlate="BRL-987"
		//	},
		//	new ControlInOut {
		//		Id=21,
		//		VehicleTypeId=3,
		//		AccordTypeId=2,
		//		DateTimeIn=DateTime.Now.Date.AddHours(22).AddMinutes(0),
		//		DateTimeOut=null,
		//		LicensePlate="BRL-951"
		//	},
		//	new ControlInOut {
		//		Id=22,
		//		VehicleTypeId=3,
		//		AccordTypeId=4,
		//		DateTimeIn=DateTime.Now.Date.AddHours(23).AddMinutes(30),
		//		DateTimeOut=null,
		//		LicensePlate="BRL-357"
		//	}
		// };
		//builder.HasData(objControlInOut);
		#endregion

	}
}
