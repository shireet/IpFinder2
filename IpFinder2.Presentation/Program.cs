using IpFinder2.BLL;
using IpFinder2.DAL;
using IpFinder2.Presentation.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IpFinder2.Presentation;

public class Program
{
    static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        
        var services = new ServiceCollection();
        services.AddDalLayer(configuration)
                .AddBllLayer()
                .AddPresentationLayer();
        
        var serviceProvider = services.BuildServiceProvider();
        var ipFinderManager = serviceProvider.GetRequiredService<IIpSearchManager>();
        ipFinderManager.Run();
    }
}