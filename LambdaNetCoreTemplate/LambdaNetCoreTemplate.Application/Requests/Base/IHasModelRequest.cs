namespace LambdaNetCoreTemplate.Application.Requests.Base
{
    public interface IHasModelRequest<T>
    {
         T Model { get; set; }
    }
}
