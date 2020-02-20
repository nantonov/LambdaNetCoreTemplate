using MediatR;

namespace LambdaNetCoreTemplate.Application.Requests.Base
{
    public abstract class HasModelRequest<TModel> : IHasModelRequest<TModel>, IRequest
    {
        public TModel Model { get; set; }
    }

    public abstract class HasModelRequest<TModel, TResponse> : IHasModelRequest<TModel>, IRequest<TResponse>
    {
        public TModel Model { get; set; }
    }
}
