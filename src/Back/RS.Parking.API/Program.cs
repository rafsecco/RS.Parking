using RS.Parking.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region ConfigureService
builder.Services.AddApiConfigureServices(builder.Configuration);
builder.Services.AddSwaggerConfigureServices();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
#region Configure
app.UseApiConfiguration();
app.UseSwaggerConfiguration();
app.UseDbMigrationHelper();
#endregion

app.Run();
