using System.Threading;
using System.Threading.Tasks;
using LambdaNetCoreTemplate.Application.Model;
using LambdaNetCoreTemplate.Application.Requests;
using MediatR;

namespace LambdaNetCoreTemplate.Application.Handlers
{
    public class ProductHandler : IRequestHandler<AddProductRequest, Product>
    {
        public Task<Product> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Product
            {
                Name = request.Model.Name + "TEST",
                Price = request.Model.Price
            });
        }
    }
}
