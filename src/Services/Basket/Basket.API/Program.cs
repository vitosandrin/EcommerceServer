var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
//TODO - ADD ASSEMBLY FOR CARTER O DI LAYER
builder.Services.AddCarter();

var app = builder.Build();

app.SetupServices();

app.MapCarter();

app.Run();