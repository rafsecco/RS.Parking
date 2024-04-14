using Microsoft.EntityFrameworkCore;
using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure;

public class RSParkingContext : DbContext
{
	public DbSet<VehicleType> VehicleTypes { get; set; }
	public DbSet<AccordType> AccordTypes { get; set; }
	public DbSet<ControlInOut> ControlInOut { get; set; }

	public RSParkingContext(DbContextOptions<RSParkingContext> options) : base(options)
	{
		ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		ChangeTracker.AutoDetectChangesEnabled = false;
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.UseCollation("utf8_general_ci"); //latin2_general_ci (Default)
		modelBuilder.HasDefaultSchema("RS.Parking");

		foreach (var property in modelBuilder.Model.GetEntityTypes()
			.SelectMany(e => e.GetProperties()
				.Where(p => p.ClrType == typeof(string))))
		{
			property.SetColumnType("VARCHAR(100)");
		}

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(RSParkingContext).Assembly);

		foreach (var relationship in modelBuilder.Model.GetEntityTypes()
			.SelectMany(e => e.GetForeignKeys()))
		{
			relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
		}

		base.OnModelCreating(modelBuilder);
	}

	//public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
	//{
	//	foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateCreated") != null))
	//	{
	//		if (entry.State == EntityState.Added)
	//		{
	//			entry.Property("DateCreated").CurrentValue = DateTime.Now;
	//		}

	//		if (entry.State == EntityState.Modified)
	//		{
	//			entry.Property("DateCreated").IsModified = false;
	//		}
	//	}

	//	return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
	//}

}
