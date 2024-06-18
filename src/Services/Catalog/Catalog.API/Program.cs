using Catalog.CrossCutting;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

//TODO - ERROR ON ROUTING WHEN USING CARTER IN DIFFERENT ASSEMBLY
//SHOULD PASS CONFIG OPTIONS TO USECARTE WITH MODULE FROM API
builder.Services.AddCarter();

var app = builder.Build();

app.MapCarter();

app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.Run();