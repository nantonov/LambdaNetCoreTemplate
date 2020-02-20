using System;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using LambdaNetCoreTemplate.Application.Model;
using LambdaNetCoreTemplate.Application.Requests;
using LambdaNetCoreTemplate.Lambda.Functions.Base;
using LambdaNetCoreTemplate.Lambda.Responses;

namespace LambdaNetCoreTemplate.Lambda.Functions.ProductFunctions
{
    public class CreateFunction : BaseFunction
    {
        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public async Task<APIGatewayProxyResponse> CreateAsync(APIGatewayProxyRequest request, ILambdaContext context)
        {
            try
            {
                var response = await Process<AddProductRequest, Product, Product>(request.Body);
                return ApiGatewayResponse.Ok(response);
            }
            catch (Exception e)
            {
                LambdaLogger.Log(e.Message);
                return ApiGatewayResponse.BadRequest(e.Message);
            }
        }
    }
}
