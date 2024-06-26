namespace Basket.CrossCutting;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var handlersAssembly = Assembly.Load("Basket.Application");
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
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.Decorate<IBasketRepository, CachedBasketRepository>();
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMarten(opts =>
        {
            opts.Connection(configuration.GetConnectionString("Database")!);
            opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);
        }).UseLightweightSessions();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
        });

        services.AddHealthChecks()
            .AddNpgSql(configuration.GetConnectionString("Database")!)
            .AddRedis(configuration.GetConnectionString("Redis")!);

        return services;
    }
}
