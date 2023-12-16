using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Infrastructure.Extensions;

namespace Phoenix.UI;

public class Startup
{
    private IConfiguration Configuration => Configure();


    public IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddRepositories();
        services.AddServices();
        services.AddHttpClients(Configuration);
        return services.BuildServiceProvider();
    }

    private Func<IConfiguration> Configure => () => new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile
            ("appsettings.json")
        .Build();
}