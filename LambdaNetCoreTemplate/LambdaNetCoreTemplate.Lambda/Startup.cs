using System;
using Amazon.SimpleNotificationService;
using LambdaNetCoreTemplate.Application.DI;
using Microsoft.Extensions.DependencyInjection;

namespace LambdaNetCoreTemplate.Lambda
{
    internal static class Startup
    {
        internal static IServiceProvider BuildDependencies()
        {
            var services = new ServiceCollection();

            services.AddScoped<AmazonSimpleNotificationServiceClient>();
            services.RegisterDependencies();

            return services.BuildServiceProvider(); 
        }
    }
}
