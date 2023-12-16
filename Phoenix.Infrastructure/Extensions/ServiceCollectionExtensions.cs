using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Infrastructure.Abstractions;
using Phoenix.Infrastructure.Data;
using Phoenix.Infrastructure.Data.Repositories;
using Phoenix.Infrastructure.Services;

namespace Phoenix.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IUserCommentService, UserCommentService>();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddDbContext<PhoenixDbContext>();
        services.AddTransient<IUserCommentRepository, UserCommentRepository>();
        return services;
    }

    public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        var uri = new Uri(configuration.GetSection("Api")["Url"]);
        services.AddHttpClient("pars-pack",
            client => { client.BaseAddress = uri; });
        return services;
    }
}