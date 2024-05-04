using Microsoft.OpenApi.Models;

namespace RS.Parking.API.Configurations;

public static class SwaggerConfigs
{
	public static IServiceCollection AddSwaggerConfigureServices(this IServiceCollection services)
	{
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo { Title = "RS.Parking.API", Version = "v1" });
		});
		return services;
	}

	public static WebApplication UseSwaggerConfiguration(this WebApplication app)
	{
		// Configure the HTTP request pipeline.
		//if (env.IsDevelopment() || env.IsEnvironment("Docker"))
		if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
		{
			app.UseSwagger();
			app.UseSwaggerUI(c => 
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "RS.Parking.API v1")
			);
		}
		return app;
	}
}
