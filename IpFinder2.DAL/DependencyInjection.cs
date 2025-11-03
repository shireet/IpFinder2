using IpFinder2.DAL.Implementations;
 using IpFinder2.DAL.Interfaces;
 using IpFinder2.DAL.Settings;
 using Microsoft.Extensions.Configuration;
 using Microsoft.Extensions.DependencyInjection;
 using Microsoft.Extensions.Options;
 
 namespace IpFinder2.DAL;
 
 public static class DependencyInjection
 {
     public static IServiceCollection AddDalLayer(this IServiceCollection services, IConfiguration configuration)
     {
         services.Configure<IpRepositorySettings>(configuration.GetSection("IpRepositorySettings"));

         services.AddSingleton<ISubnetRepository>(serviceProvider =>
         {
             var options = serviceProvider.GetRequiredService<IOptions<IpRepositorySettings>>();
             var settings = options.Value;

             if (string.IsNullOrEmpty(settings.ZipPath))
                 throw new InvalidOperationException("ZipPath configuration is missing in appsettings.json");
            
             if (string.IsNullOrEmpty(settings.FileName))
                 throw new InvalidOperationException("FileName configuration is missing in appsettings.json");

             return new SubnetRepository(settings.ZipPath, settings.FileName);
         });

         return services;
     }
 }