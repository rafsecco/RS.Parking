using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using RS.Parking.Infrastructure;

namespace RS.Parking.API.Configurations;

public static class ApiConfigs
{
	public static IServiceCollection AddApiConfigureServices(this IServiceCollection services, IConfiguration configurations)
	{
		string strConn = configurations.GetConnectionString("ConnMariaDB");

		services.AddDbContext<RSParkingContext>(options => options
			.UseMySql(strConn, ServerVersion.AutoDetect(strConn), e => 
			{
				e.EnableRetryOnFailure(
					maxRetryCount: 3,
					maxRetryDelay: TimeSpan.FromSeconds(5),
					errorNumbersToAdd: null);
				e.SchemaBehavior(MySqlSchemaBehavior.Ignore);
			})
			.LogTo(Console.WriteLine)
			.EnableSensitiveDataLogging()
			.EnableDetailedErrors()
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
		//app.UseHttpsRedirection();

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
