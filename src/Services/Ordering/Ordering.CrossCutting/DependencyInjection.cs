namespace Catalog.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var handlersAssembly = Assembly.Load("Ordering.Application");
        var validatorsAssembly = Assembly.Load("Contracts");

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(handlersAssembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
        services.AddValidatorsFromAssembly(validatorsAssembly);
        services.AddExceptionHandler<CustomExceptionHandler>();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

}
