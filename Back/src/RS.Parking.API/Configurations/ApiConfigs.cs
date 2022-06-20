﻿using Microsoft.EntityFrameworkCore;
using RS.Parking.API.Data;

namespace RS.Parking.API.Configurations;

public static class ApiConfigs
{
	public static IServiceCollection AddApiConfigureServices(this IServiceCollection services, IConfiguration configurations)
	{
		services.AddDbContext<DataContext>(context => 
			context.UseSqlite(configurations.GetConnectionString("Default"))
		);

		services.AddControllers();

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
		app.MapControllers();
		//app.UseEndpoints(endpoints =>
		//{
		//	endpoints.MapControllers();
		//});

		return app;
	}
}