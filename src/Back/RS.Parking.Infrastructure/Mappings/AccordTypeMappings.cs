using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure.Mappings;

internal class AccordTypeMappings : IEntityTypeConfiguration<AccordType>
{
	public void Configure(EntityTypeBuilder<AccordType> builder)
	{
		builder.ToTable("tb_AccordType")
			.HasKey(k => k.Id);

		builder.Property(p => p.Id)
			.HasColumnName("id_accord")
			.HasColumnType("TINYINT UNSIGNED")  //System.Byte 
			.ValueGeneratedOnAdd();

		builder.Property(p => p.Active)
			.IsRequired()
			.HasColumnName("bln_active");

		builder.Property(p => p.DateCreated)
			.IsRequired()
			.HasColumnName("dt_dateCreated")
			.HasDefaultValueSql("NOW()");

		builder.Property(p => p.DiscountTypeId)
			.IsRequired()
			.HasColumnName("ie_accord");

		builder.Property(p => p.Percentage)
			.IsRequired()
			.HasColumnName("nr_percentage")
			.HasPrecision(3, 2);

		builder.Property(p => p.Description)
			.IsRequired()
			.HasColumnName("ds_accord")
			.HasMaxLength(100);

		//builder.Ignore(i => i.ControlInOut);

		#region Populate
		//AccordType[] objAccordType = {
		//	new AccordType { Id=1, Active=true, DiscountTypeId=0, Percentage=0, Description="No Discount" },
		//	new AccordType { Id=2, Active=true, DiscountTypeId=1, Percentage=0.5, Description="Subway" },
		//	new AccordType { Id=3, Active=true, DiscountTypeId=2, Percentage=1, Description="McDonald's" },
		//	new AccordType { Id=4, Active=true, DiscountTypeId=2, Percentage=0.5, Description="PharmaTech" }
		//};
		//builder.HasData(objAccordType);
		#endregion
	}
}
