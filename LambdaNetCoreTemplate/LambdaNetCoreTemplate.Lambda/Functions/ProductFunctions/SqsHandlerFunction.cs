using System;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;

namespace LambdaNetCoreTemplate.Lambda.Functions.ProductFunctions
{
    public class SqsHandlerFunction
    {
        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public void SqsHandler(SQSEvent sqsEvent, ILambdaContext context)
        {
            Console.WriteLine("SQS EVENT");
            var messages = sqsEvent.Records;

            foreach (var msg in messages)
            {
                Console.WriteLine($"SQS Message ID: {msg.MessageId} SQS Message Body: {msg.Body}");
            }
        }
    }
}
