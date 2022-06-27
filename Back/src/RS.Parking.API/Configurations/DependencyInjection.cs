using RS.Parking.Application;
using RS.Parking.Application.Contracts;
using RS.Parking.Infrastructure.Contracts;
using RS.Parking.Infrastructure.Repositories;

namespace RS.Parking.API.Configurations;

public static class DependencyInjection
{
	public static void RegisterServices(this IServiceCollection services)
	{
		services.AddScoped<ICoreRepository, CoreRepository>();

		services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
		services.AddScoped<IVehicleTypeService, VehicleTypeService>();
	}
}
