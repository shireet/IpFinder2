using IpFinder2.Presentation.Implementations;
using IpFinder2.Presentation.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IpFinder2.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationLayer(this IServiceCollection services)
    {
        services.AddScoped<IIpSearchManager, IpSearchManager>();
        return services;
    }
}