namespace LambdaNetCoreTemplate.Application.Requests.Base
{
    public class HasModelRequest<T> : IHasModelRequest<T>
    {
        public T Model { get; set; }
    }
}
