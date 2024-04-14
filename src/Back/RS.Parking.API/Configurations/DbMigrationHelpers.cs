using Microsoft.EntityFrameworkCore;
using RS.Parking.Domain.Models;
using RS.Parking.Infrastructure;

namespace RS.Parking.API.Configurations;

public static class DbMigrationHelperExtension
{
	public static void UseDbMigrationHelper(this WebApplication app)
	{
		DbMigrationHelpers.EnsureSeedData(app).Wait();
	}
}

public static class DbMigrationHelpers
{
	public static async Task EnsureSeedData(WebApplication app)
	{
		var services = app.Services.CreateScope().ServiceProvider;
		await EnsureSeedData(services);
	}

	private static async Task EnsureSeedData(IServiceProvider serviceProvider)
	{
		using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
		var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

		var context = scope.ServiceProvider.GetRequiredService<RSParkingContext>();

		if (env.IsDevelopment() || env.IsEnvironment("Docker"))
		{
			await context.Database.EnsureCreatedAsync(); // Este comando apenas quando tiver apenas 1 contexto
			//await context.Database.MigrateAsync();	// Este paara quando tiver mais de 1 contexto
			await EnsureSeedTables(context);
		}
	}

	private static async Task EnsureSeedTables(RSParkingContext context)
	{
		if (!context.VehicleTypes.Any())
		{
			VehicleType[] vehicleTypeList = {
				new VehicleType {Id=1, Active=true, Cost=4m, Description="Car 1 (small)" },
				new VehicleType {Id=2, Active=true, Cost=5.5m, Description="Car 2 (big)" },
				new VehicleType {Id=3, Active=true, Cost=3m, Description="Moto 1" },
			};
			await context.VehicleTypes.AddRangeAsync(vehicleTypeList);
			await context.SaveChangesAsync();
		}

		if (!context.AccordTypes.Any())
		{
			AccordType[] accordTypeList = {
				new AccordType { Id=1, Active=true, DiscountTypeId=0, Percentage=0, Description="No Discount" },
				new AccordType { Id=2, Active=true, DiscountTypeId=1, Percentage=0.5, Description="Subway" },
				new AccordType { Id=3, Active=true, DiscountTypeId=2, Percentage=1, Description="McDonald's" },
				new AccordType { Id=4, Active=true, DiscountTypeId=2, Percentage=0.5, Description="PharmaTech" }
			};
			await context.AccordTypes.AddRangeAsync(accordTypeList);
			await context.SaveChangesAsync();
		}

		if (!context.ControlInOut.Any())
		{
			ControlInOut[] controlInOutList =
			{
				new ControlInOut {
					Id=1,
					VehicleTypeId=1,
					AccordTypeId=1,
					DateTimeIn=DateTime.Now.Date.AddDays(-1).AddHours(8).AddMinutes(0),
					DateTimeOut=DateTime.Now.Date.AddDays(-1).AddHours(10).AddMinutes(0),
					LicensePlate="BRL-123",
				 },
		 		new ControlInOut {
					Id=2,
					VehicleTypeId=1,
					AccordTypeId=2,
					DateTimeIn=DateTime.Now.Date.AddDays(-1).AddHours(10).AddMinutes(0),
					DateTimeOut=DateTime.Now.Date.AddDays(-1).AddHours(12).AddMinutes(30),
					LicensePlate="BRL-456"
				},
				new ControlInOut {
					Id=3,
					VehicleTypeId=1,
					AccordTypeId=3,
					DateTimeIn=DateTime.Now.Date.AddDays(-1).AddHours(12).AddMinutes(30),
					DateTimeOut=DateTime.Now.Date.AddDays(-1).AddHours(14).AddMinutes(30),
					LicensePlate="BRL-789"
				},
				new ControlInOut {
					Id=4,
					VehicleTypeId=1,
					AccordTypeId=4,
					DateTimeIn=DateTime.Now.Date.AddDays(-1).AddHours(16).AddMinutes(30),
					DateTimeOut=DateTime.Now.Date.AddDays(-1).AddHours(18).AddMinutes(30),
					LicensePlate="BRL-147"
				},

				new ControlInOut {
					Id=5,
					VehicleTypeId=2,
					AccordTypeId=1,
					DateTimeIn=DateTime.Now.Date.AddDays(-2).AddHours(8).AddMinutes(0),
					DateTimeOut=DateTime.Now.Date.AddDays(-2).AddHours(10).AddMinutes(0),
					LicensePlate="BRL-123",
				 },
		 		new ControlInOut {
					Id=6,
					VehicleTypeId=2,
					AccordTypeId=2,
					DateTimeIn=DateTime.Now.Date.AddDays(-2).AddHours(10).AddMinutes(0),
					DateTimeOut=DateTime.Now.Date.AddDays(-2).AddHours(12).AddMinutes(30),
					LicensePlate="BRL-456"
				},
				new ControlInOut {
					Id=7,
					VehicleTypeId=2,
					AccordTypeId=3,
					DateTimeIn=DateTime.Now.Date.AddDays(-2).AddHours(12).AddMinutes(30),
					DateTimeOut=DateTime.Now.Date.AddDays(-2).AddHours(14).AddMinutes(30),
					LicensePlate="BRL-789"
				},
				new ControlInOut {
					Id=8,
					VehicleTypeId=2,
					AccordTypeId=4,
					DateTimeIn=DateTime.Now.Date.AddDays(-2).AddHours(16).AddMinutes(30),
					DateTimeOut=DateTime.Now.Date.AddDays(-2).AddHours(18).AddMinutes(30),
					LicensePlate="BRL-147"
				},

				new ControlInOut {
					Id=9,
					VehicleTypeId=3,
					AccordTypeId=1,
					DateTimeIn=DateTime.Now.Date.AddDays(-3).AddHours(8).AddMinutes(0),
					DateTimeOut=DateTime.Now.Date.AddDays(-3).AddHours(10).AddMinutes(0),
					LicensePlate="BRL-123",
				 },
		 		new ControlInOut {
					Id=10,
					VehicleTypeId=3,
					AccordTypeId=2,
					DateTimeIn=DateTime.Now.Date.AddDays(-3).AddHours(10).AddMinutes(0),
					DateTimeOut=DateTime.Now.Date.AddDays(-3).AddHours(12).AddMinutes(30),
					LicensePlate="BRL-456"
				},
				new ControlInOut {
					Id=11,
					VehicleTypeId=3,
					AccordTypeId=3,
					DateTimeIn=DateTime.Now.Date.AddDays(-3).AddHours(12).AddMinutes(30),
					DateTimeOut=DateTime.Now.Date.AddDays(-3).AddHours(14).AddMinutes(30),
					LicensePlate="BRL-789"
				},
				new ControlInOut {
					Id=12,
					VehicleTypeId=3,
					AccordTypeId=4,
					DateTimeIn=DateTime.Now.Date.AddDays(-3).AddHours(16).AddMinutes(30),
					DateTimeOut=DateTime.Now.Date.AddDays(-3).AddHours(18).AddMinutes(30),
					LicensePlate="BRL-147"
				},

				new ControlInOut {
					Id=13,
					VehicleTypeId=1,
					AccordTypeId=1,
					DateTimeIn=DateTime.Now.Date.AddHours(8).AddMinutes(0),
					DateTimeOut=null,
					LicensePlate="BRL-123",
				 },
		 		new ControlInOut {
					Id=14,
					VehicleTypeId=2,
					AccordTypeId=2,
					DateTimeIn=DateTime.Now.Date.AddHours(10).AddMinutes(0),
					DateTimeOut=null,
					LicensePlate="BRL-456"
				},
				new ControlInOut {
					Id=15,
					VehicleTypeId=3,
					AccordTypeId=3,
					DateTimeIn=DateTime.Now.Date.AddHours(12).AddMinutes(30),
					DateTimeOut=null,
					LicensePlate="BRL-789"
				},
				new ControlInOut {
					Id=16,
					VehicleTypeId=1,
					AccordTypeId=4,
					DateTimeIn=DateTime.Now.Date.AddHours(16).AddMinutes(30),
					DateTimeOut=null,
					LicensePlate="BRL-147"
				},
				new ControlInOut {
					Id=17,
					VehicleTypeId=2,
					AccordTypeId=1,
					DateTimeIn=DateTime.Now.Date.AddHours(18).AddMinutes(0),
					DateTimeOut=null,
					LicensePlate="BRL-753"
				},
				new ControlInOut {
					Id=18,
					VehicleTypeId=2,
					AccordTypeId=3,
					DateTimeIn=DateTime.Now.Date.AddHours(19).AddMinutes(30),
					DateTimeOut=null,
					LicensePlate="BRL-321"
				},
				new ControlInOut {
					Id=19,
					VehicleTypeId=2,
					AccordTypeId=4,
					DateTimeIn=DateTime.Now.Date.AddHours(20).AddMinutes(0),
					DateTimeOut=null,
					LicensePlate="BRL-654"
				},
				new ControlInOut {
					Id=20,
					VehicleTypeId=3,
					AccordTypeId=1,
					DateTimeIn=DateTime.Now.Date.AddHours(21).AddMinutes(30),
					DateTimeOut=null,
					LicensePlate="BRL-987"
				},
				new ControlInOut {
					Id=21,
					VehicleTypeId=3,
					AccordTypeId=2,
					DateTimeIn=DateTime.Now.Date.AddHours(22).AddMinutes(0),
					DateTimeOut=null,
					LicensePlate="BRL-951"
				},
				new ControlInOut {
					Id=22,
					VehicleTypeId=3,
					AccordTypeId=4,
					DateTimeIn=DateTime.Now.Date.AddHours(23).AddMinutes(30),
					DateTimeOut=null,
					LicensePlate="BRL-357"
				}
			};
			await context.ControlInOut.AddRangeAsync(controlInOutList);
			await context.SaveChangesAsync();
		}
	}
}