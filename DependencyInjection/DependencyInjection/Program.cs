using DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//code to register service to service collection
var weatherService = new ServiceDescriptor(typeof(WeatherForecast), a => new WeatherForecast(), ServiceLifetime.Scoped);
builder.Services.Add(weatherService);

//code to register service using extension method
builder.Services.AddTransient<WeatherForecast, WeatherForecast>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
