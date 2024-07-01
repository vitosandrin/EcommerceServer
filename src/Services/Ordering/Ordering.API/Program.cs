using Ordering.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.SetupServices();

//TODO: ADD THIS CODE ON DI LAYER
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.MapGet("/", () => "Hello World!");

app.Run();
