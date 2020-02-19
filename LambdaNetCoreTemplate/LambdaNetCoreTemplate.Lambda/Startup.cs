using System;
using LambdaNetCoreTemplate.Application.DI;
using Microsoft.Extensions.DependencyInjection;

namespace LambdaNetCoreTemplate.Lambda
{
    internal class Startup
    {
        internal static IServiceProvider BuildDependencies()
        {
            var services = new ServiceCollection();

            services.RegisterDependencies();

            return services.BuildServiceProvider(); 
        }
    }
}
