using Catalog.API.Data;
using Contracts.Exceptions.Handler;

namespace Catalog.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var handlersAssembly = Assembly.Load("Catalog.Application");
        var validatorsAssembly = Assembly.Load("Contracts");

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(handlersAssembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
        services.AddValidatorsFromAssembly(validatorsAssembly);

        services.AddMarten(opts =>
        {
            opts.Connection(configuration.GetConnectionString("Database")!);
        }).UseLightweightSessions();

        services.AddExceptionHandler<CustomExceptionHandler>();
        services.InitializeMartenWith<CatalogInitialData>();
        services.AddHealthChecks().AddNpgSql(configuration.GetConnectionString("Database")!);

        return services;
    }
}
