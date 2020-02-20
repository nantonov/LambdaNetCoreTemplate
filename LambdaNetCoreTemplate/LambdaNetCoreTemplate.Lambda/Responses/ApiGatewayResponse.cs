using System.Net;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;

namespace LambdaNetCoreTemplate.Lambda.Responses
{
    public static class ApiGatewayResponse
    {
        public static APIGatewayProxyResponse Response(string jsonBody, HttpStatusCode code)
            => new APIGatewayProxyResponse
            {
                StatusCode = (int)code,
                Body = jsonBody
            };

        public static APIGatewayProxyResponse Ok() => Ok(string.Empty);
        public static APIGatewayProxyResponse Ok(object body) => Ok(JsonConvert.SerializeObject(body));
        public static APIGatewayProxyResponse Ok(string jsonBody) => Response(jsonBody, HttpStatusCode.OK);

        public static APIGatewayProxyResponse BadRequest() => BadRequest(string.Empty);
        public static APIGatewayProxyResponse BadRequest(object body) => BadRequest(JsonConvert.SerializeObject(body));
        public static APIGatewayProxyResponse BadRequest(string jsonBody) => Response(jsonBody, HttpStatusCode.BadRequest);

        public static APIGatewayProxyResponse InternalServerError() => InternalServerError(string.Empty);
        public static APIGatewayProxyResponse InternalServerError(object body) => InternalServerError(JsonConvert.SerializeObject(body));
        public static APIGatewayProxyResponse InternalServerError(string jsonBody) => Response(jsonBody, HttpStatusCode.InternalServerError);
    }
}
