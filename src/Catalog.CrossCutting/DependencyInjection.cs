using System.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

using MediatR;
using Microsoft.Data.SqlClient;

using Catalog.Domain.Abstractions;
using Catalog.Infrastructure.Context;
using Catalog.Infrastructure.Repositories;

namespace CqrsDemo.CrossCutting.AppDependencies;

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

        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IUnityOfWork, UnityOfWork>();
        services.AddScoped<IMemberDapperRepository, MemberDapperRepository>();

        var handlersAssembly = Assembly.Load("CqrsDemo.Application");

        services.AddMediatR(cfg =>
        {
            //register all handlers from the assembly
            cfg.RegisterServicesFromAssemblies(handlersAssembly);
            //register all validators from the assembly
            cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        services.AddValidatorsFromAssembly(handlersAssembly);

        return services;
    }
}