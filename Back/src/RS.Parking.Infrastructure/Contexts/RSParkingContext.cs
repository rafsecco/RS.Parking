using Microsoft.EntityFrameworkCore;
using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure.Contexts;

public class RSParkingContext : DbContext
{
	public DbSet<VehicleType> VehicleTypes { get; set; }
	public DbSet<AccordType> AccordTypes { get; set; }
	public DbSet<ControlInOut> ControlInOut { get; set; }

	public RSParkingContext(DbContextOptions<RSParkingContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ControlInOut>()
			.HasKey(CIO => new { CIO.VehicleTypeId, CIO.AccordTypeId });

		//modelBuilder.UseCollation("utf8_general_ci"); //latin2_general_ci (Default)
		//modelBuilder.HasDefaultSchema("RS.Parking");

		//modelBuilder.ApplyConfiguration(new VehicleTypeConfigurations());
		//modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		//modelBuilder.ApplyConfigurationsFromAssembly(typeof(RSParkingContext).Assembly);

		//foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
		//{
		//	relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
		//}

		base.OnModelCreating(modelBuilder);
	}

	//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//{
	//	//const string strConn = "Server = localhost; Port = 3306; Database = RS.Parking; Uid = RSParkingSystem; Pwd = RsParking@123;";
	//	//var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
	//	var serverVersion = ServerVersion.AutoDetect(_connectionString);

	//	optionsBuilder
	//		.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
	//		.EnableSensitiveDataLogging()
	//		.EnableDetailedErrors()
	//		.UseMySql(_connectionString, serverVersion, e =>
	//		{
	//			e.EnableRetryOnFailure(
	//				maxRetryCount: 3,
	//				maxRetryDelay: TimeSpan.FromSeconds(5),
	//				errorNumbersToAdd: null);
	//		});
	//}

	//#region Para desenvolvimento
	//public void EnsureCreated()
	//{
	//	var dbOptions = new DbContextOptions<RSParkingContext>();
	//	using var db = new RSParkingContext(dbOptions);
	//	db.Database.EnsureCreated();
	//}

	//public void EnsureDeleted()
	//{
	//	var dbOptions = new DbContextOptions<RSParkingContext>();
	//	using var db = new RSParkingContext(dbOptions);
	//	db.Database.EnsureDeleted();
	//}
	//#endregion
}
