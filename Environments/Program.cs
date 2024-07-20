var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Environment in app(Web Application) contains information about the Environment
// -- To run application is different environment,
// step1 :- in the powershell run $Env:ASPNETCORE_ENVIRONMENT = 'Staging(Env you want to run app in)' 
// step2 :- run dotnet run --no-launch-profile
Console.WriteLine($"Hey, I am running on {app.Environment.EnvironmentName} Environment.");

//Retrives the config value from config file and logs it, appsettings.{Environemnt}.json file overrides appsettings.json file
app.Logger.LogInformation($"MyConfig value is from {app.Configuration.GetValue<string>("MyConfig")}");

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
