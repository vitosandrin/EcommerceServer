namespace Catalog.CrossCutting;

public static class Setup
{
    public static IApplicationBuilder SetupServices(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(options => { });

        return app;
    }
}
