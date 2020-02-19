using LambdaNetCoreTemplate.Application.Model;
using LambdaNetCoreTemplate.Application.Requests.Base;
using MediatR;

namespace LambdaNetCoreTemplate.Application.Requests
{
    public class AddProductRequest : HasModelRequest<Product>, IRequest<Product>
    {
    }
}
