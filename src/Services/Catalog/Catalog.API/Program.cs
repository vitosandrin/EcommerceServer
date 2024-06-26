var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddRepositories();
builder.Services.AddDatabase(builder.Configuration);

//TODO - ADD ASSEMBLY FOR CARTER O DI LAYER
builder.Services.AddCarter();

var app = builder.Build();

app.MapCarter();

app.SetupServices();

app.Run();