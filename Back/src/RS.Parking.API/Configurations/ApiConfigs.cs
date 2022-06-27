using Microsoft.EntityFrameworkCore;
using RS.Parking.Infrastructure.Contexts;

namespace RS.Parking.API.Configurations;

public static class ApiConfigs
{
	public static IServiceCollection AddApiConfigureServices(this IServiceCollection services, IConfiguration configurations)
	{
		services.AddDbContext<RSParkingContext>(context => 
			context.UseSqlite(configurations.GetConnectionString("Default"))
		);

		services.AddControllers();
		//services.AddControllers()
		//	.AddNewtonsoftJson(x => 
		//		x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
		//	);

		services.RegisterServices();

		services.AddCors();

		return services;
	}

	public static WebApplication UseApiConfiguration(this WebApplication app)
	{
		app.UseHttpsRedirection();
		//app.UseCors("Development");
		//app.UseRouting();

		if (app.Environment.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}
		//else
		//{
		//	app.UseHsts();
		//}

		app.UseAuthorization();

		app.UseCors(x => x.AllowAnyHeader()
			.AllowAnyMethod()
			.AllowAnyOrigin()
		);

		app.MapControllers();
		//app.UseEndpoints(endpoints =>
		//{
		//	endpoints.MapControllers();
		//});

		return app;
	}
}
