
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using LambdaNetCoreTemplate.Application.Model;
using LambdaNetCoreTemplate.Application.Requests;
using LambdaNetCoreTemplate.Lambda.Functions.Base;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace LambdaNetCoreTemplate.Lambda.Functions
{
    public class Function : BaseFunction
    {
        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var requestModel = new AddProductRequest
            {
                Model = JsonConvert.DeserializeObject<Product>(request.Body)
            };

            var mediator = ServiceProvider.GetRequiredService<IMediator>();
            var result = await mediator.Send(requestModel);

            return new APIGatewayProxyResponse { Body = JsonConvert.SerializeObject(result), StatusCode = 200 };
        }
    }
}