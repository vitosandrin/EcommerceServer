using System.Data;
using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Catalog.Infrastructure.Repositories;
using Contracts.Abstractions;
using Catalog.Infrastructure.Context;

namespace Catalog.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConnectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConnectionString));
        services.AddSingleton<IDbConnection>(provider =>
        {
            var connection = new SqlConnection(dbConnectionString);
            connection.Open();
            return connection;
        });

        services.AddScoped<IUnityOfWork, UnityOfWork>();

        var handlersAssembly = Assembly.Load("Catalog.Application");

        services.AddMediatR(cfg =>
        {
            //register all handlers from the assembly
            cfg.RegisterServicesFromAssemblies(handlersAssembly);
            //register all validators from the assembly

            //cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        services.AddValidatorsFromAssembly(handlersAssembly);

        return services;
    }
}
