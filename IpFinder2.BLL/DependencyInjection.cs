using IpFinder2.BLL.Implementations;
using IpFinder2.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IpFinder2.BLL;

public static class DependencyInjection
{
    public static IServiceCollection AddBllLayer(this IServiceCollection services)
    {
        services.AddSingleton<IIpSearcher, IpSearcher>();
        return services;
    }
}