using System;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.SimpleNotificationService.Model;
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
                await Process<AddProductRequest, Product>(request.Body);

                var publishRequest = new PublishRequest();
                publishRequest.TopicArn = "arn:aws:sns:eu-west-2:304639198633:ProductTopic";
                publishRequest.Message = request.Body;

                await PublishToSns(publishRequest);

                return ApiGatewayResponse.Ok();
            }
            catch (Exception e)
            {
                LambdaLogger.Log(e.Message);
                return ApiGatewayResponse.BadRequest(e.Message);
            }
        }
    }
}
