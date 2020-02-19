using System;

namespace LambdaNetCoreTemplate.Lambda.Functions.Base
{
    public abstract class BaseFunction
    {
        protected readonly IServiceProvider ServiceProvider;

        protected BaseFunction()
        {
            ServiceProvider = Startup.BuildDependencies();
        }
    }
}
