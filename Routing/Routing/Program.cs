var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// This is point in middleware pipeline where a particular route is matched with a particular endpoint
app.UseRouting();

//========= this is top level route registration, It can also be done using useEndpoints method=========
app.MapGet("/topLevelRoute", async context =>
{
    var name = context.GetRouteValue("");
    await context.Response.WriteAsync("Hello from /topLevelRoute");
});

//This middleware configures and executes the selected endpoint by the app.UseRouting()
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/{name:alpha?}", async context =>
    {
        var name = context.GetRouteValue("name");
await context.Response.WriteAsync($"Hello {name}");
    });
});

//========== This method is used to add controller methods as endpoints for Route Matching ==================
app.MapControllers();

app.Run();
