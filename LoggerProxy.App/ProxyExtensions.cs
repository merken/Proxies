using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LoggerProxy.App
{
    public static class ProxyExtensions
    {
        public static IServiceCollection AddAsLoggerProxy<TInterface, TImplementation>(this IServiceCollection services)
            where TInterface : class
            where TImplementation : class
        {
            // First, register the actual implementation type to allow for DI to happen on that object
            services.AddScoped<TImplementation>();
            // Second, register the interface that will be injected into the FooController
            services.AddScoped<TInterface>(sp =>
            {
                // Resolve the implementation type, the ForeignService
                var actualService = sp.GetRequiredService<TImplementation>();
                // Create a logger proxy for IFooService
                var loggerService = DispatchProxy.Create<TInterface, LoggerProxy>();
                // Set the proxy remote object
                (loggerService as LoggerProxy).SetRemoteObject(actualService);

                // Return as IFooService
                return loggerService;
            });

            return services;
        }
    }
}