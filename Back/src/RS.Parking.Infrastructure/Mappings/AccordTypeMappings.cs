//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using RS.Parking.Domain.Models;

//namespace RS.Parking.Infrastructure.Mappings;

//internal class AccordTypeMappings : IEntityTypeConfiguration<AccordType>
//{
//	public void Configure(EntityTypeBuilder<AccordType> builder)
//	{
//		builder.ToTable("tb_AccordType")
//			.HasKey(k => k.Id);

//		builder.Property(p => p.Id)
//			.HasColumnName("id_accord")
//			.HasColumnType("TINYINT UNSIGNED")  //System.Byte 
//			.ValueGeneratedOnAdd();

//		builder.Property(p => p.Description)
//			.IsRequired()
//			.HasColumnName("ds_accord")
//			.HasColumnType("VARCHAR(100)");

//		builder.Property(p => p.Accord)
//			.IsRequired()
//			.HasColumnName("ie_accord")
//			.HasColumnType("TINYINT");

//		builder.Property(p => p.Accord)
//			.IsRequired()
//			.HasColumnName("nr_accord")
//			.HasColumnType("DECIMAL")
//			.HasPrecision(5, 2);

//		builder.Property(p => p.Active)
//			.IsRequired()
//			.HasColumnName("bln_active")
//			.HasColumnType("BOOLEAN");

//		builder.Property(p => p.DateCreated)
//			.IsRequired()
//			.HasColumnName("dt_dateCreated")
//			.HasDefaultValueSql("NOW()");

//		//builder.HasData(new[]
//		//{
//		//	new AccordType(),
//		//	new AccordType()
//		//});

//	}
//}
