using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApp
{
    public static class ServiceBusSubscriptionTriggerFunction
    {
        [FunctionName("ServiceBusSubscriptionTriggerFunction")]
        public static void Run(
            [ServiceBusTrigger("@replace-with-topic-name", "@replace-with-subscription-name")] string myMessage,
            int deliveryCount, // message metadata
            string messageId, // message metadata
            ILogger log)
        {
            log.LogInformation($"Processing message: {messageId}, delivery count: {deliveryCount}");
            log.LogInformation($"Message content: {myMessage}");
            log.LogInformation($"Finished processing message");
        }
    }
}
