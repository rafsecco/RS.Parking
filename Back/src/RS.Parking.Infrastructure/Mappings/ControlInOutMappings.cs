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

		#region Owned Types
		//builder.OwnsOne(v => v.VehicleType);
		//builder.OwnsOne(a => a.AccordType);
		#endregion
	}
}

