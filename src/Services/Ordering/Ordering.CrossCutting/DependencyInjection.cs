using Microsoft.EntityFrameworkCore;
using Ordering.Infrastructure.Abstractions;
using Ordering.Infrastructure.Data;

namespace Ordering.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);

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
        var connectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            // options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });

        //services.AddHealthChecks().AddSqlServer(connectionString);

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        return services;
    }

}
