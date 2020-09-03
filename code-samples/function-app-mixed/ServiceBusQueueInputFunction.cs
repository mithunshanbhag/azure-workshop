using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApp
{
    public static class ServiceBusQueueTriggerFunction
    {
        [FunctionName("ServiceBusQueueTriggerFunction")]
        public static void Run(
            [ServiceBusTrigger("myqueue")] string myQueueItem,
            DateTime EnqueuedTimeUtc, // message metadata
            int DeliveryCount, // message metadata
            string MessageId, // message metadata
            ILogger log)
        {
            log.LogInformation($"Processing message: {MessageId}, enqueued at {EnqueuedTimeUtc}");
            log.LogInformation($"Message content: {myQueueItem}");
            log.LogInformation($"Finished processing message");
        }
    }
}
