var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.SetupServices();

app.MapGet("/", () => "Hello World!");

app.Run();
