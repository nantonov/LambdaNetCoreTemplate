using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LambdaNetCoreTemplate.Application.DI
{
    public static class DependencyRegistrator
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyRegistrator).Assembly);
        }
    }
}
