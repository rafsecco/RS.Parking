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

		builder.Property(p => p.Accord)
			.IsRequired()
			.HasColumnName("ie_accord")	;

		builder.Property(p => p.Percentage)
			.IsRequired()
			.HasColumnName("nr_percentage")
			.HasPrecision(5, 2);

		builder.Property(p => p.Description)
			.IsRequired()
			.HasColumnName("ds_accord")
			.HasMaxLength(100);

		#region Populate
		AccordType[] objAccordType = {
			new AccordType { Id=1, Active=true, DateCreated=DateTime.Now, Accord=0, Percentage=0m, Description="No Discount" },
			new AccordType { Id=2, Active=true, DateCreated=DateTime.Now, Accord=0, Percentage=0m, Description="PharmaTech" },
			new AccordType { Id=3, Active=true, DateCreated=DateTime.Now, Accord=1, Percentage=50.0m, Description="Subway" },
			new AccordType { Id=4, Active=true, DateCreated=DateTime.Now, Accord=2, Percentage=100m, Description="McDonald's" }
		};
		builder.HasData(objAccordType);
		#endregion
	}
}
