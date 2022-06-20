using Microsoft.EntityFrameworkCore;
using RS.Parking.API.Models;

namespace RS.Parking.API.Data;

public class DataContext : DbContext
{
	public DbSet<VehicleType> VehicleTypes { get; set; }

	public DataContext(DbContextOptions<DataContext> options) : base(options) { }
}
