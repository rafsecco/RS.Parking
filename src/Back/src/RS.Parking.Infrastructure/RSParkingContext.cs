using Microsoft.EntityFrameworkCore;
using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure;

public class RSParkingContext : DbContext
{
    public DbSet<VehicleType> VehicleTypes { get; set; }
    public DbSet<AccordType> AccordTypes { get; set; }
    public DbSet<ControlInOut> ControlInOut { get; set; }

    public RSParkingContext(DbContextOptions<RSParkingContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8_general_ci"); //latin2_general_ci (Default)
        modelBuilder.HasDefaultSchema("RS.Parking");
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RSParkingContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
