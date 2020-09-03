using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApp
{
    public static class ServiceBusQueuePoisonFunction
    {
        [FunctionName("ServiceBusQueuePoisonFunction")]
        public static void Run(
            [ServiceBusTrigger("myqueue")] string myQueueItem,
            DateTime EnqueuedTimeUtc, // message metadata
            int DeliveryCount, // message metadata
            string MessageId, // message metadata
            ILogger log)
        {
            log.LogInformation($"Processing message: {myQueueItem}");
            throw new Exception("Intentionally simulating an unhandled exception");
        }
    }
}
