using System;
using System.Threading.Tasks;
using LambdaNetCoreTemplate.Application.Requests.Base;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace LambdaNetCoreTemplate.Lambda.Functions.Base
{
    public abstract class BaseFunction
    {
        protected readonly IServiceProvider ServiceProvider;

        protected BaseFunction()
        {
            ServiceProvider = Startup.BuildDependencies();
        }

        protected async Task<TResponse> Process<TRequest, TModel, TResponse>(string json)
            where TRequest : IHasModelRequest<TModel>, new()
        {
            var request = new TRequest
            {
                Model = JsonConvert.DeserializeObject<TModel>(json)
            };

            var mediator = ServiceProvider.GetRequiredService<IMediator>();
            var result = (TResponse)await mediator.Send(request);

            return result;
        }

        protected Task Process<TRequest, TModel>(string json) 
            where TRequest : IHasModelRequest<TModel>, new()
        {
            return Process<TRequest, TModel, object>(json);
        }
    }
}
