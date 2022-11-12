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
			.IsRequired(false)
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
		 	new ControlInOut { Id=1, VehicleTypeId=1, LicensePlate="BRL-123" },
		 	new ControlInOut { Id=2, VehicleTypeId=2, LicensePlate="BRL-456" }
		 };
		builder.HasData(objControlInOut);
		#endregion

	}
}

