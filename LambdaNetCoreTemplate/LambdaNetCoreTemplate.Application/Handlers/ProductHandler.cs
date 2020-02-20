using System;
using System.Threading;
using System.Threading.Tasks;
using LambdaNetCoreTemplate.Application.Requests;
using MediatR;

namespace LambdaNetCoreTemplate.Application.Handlers
{
    public class ProductHandler : IRequestHandler<AddProductRequest>
    {
        private const int MaxPrice = 42;

        public Task<Unit> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(request.Model.Name)}: {request.Model.Name} & {nameof(request.Model.Price)}: {request.Model.Price}");

            if (request.Model.Price > MaxPrice)
            {
                throw new ArgumentException($"{nameof(request.Model.Price)} must be less than {MaxPrice} or equal.");
            }

            //PUT TO SNS

            return Unit.Task;
        }
    }
}
