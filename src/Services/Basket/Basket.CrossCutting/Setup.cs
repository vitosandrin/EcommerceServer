using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Basket.CrossCutting;

public static class Setup
{
    public static IApplicationBuilder SetupServices(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(options => { });

        app.UseHealthChecks("/health",
            new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

        return app;
    }
}
