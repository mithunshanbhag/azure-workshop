using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureWorkshop.CodeSamples.FunctionApps;

public static class ServiceBusQueueTriggerFunction
{
    [FunctionName("ServiceBusQueueTriggerFunction")]
    //[FixedDelayRetry(2, "00:00:05")]
    //[ExponentialBackoffRetry(2, "00:00:05", "00:00:30")]
    public static void Run(
        [ServiceBusTrigger("myqueue1", Connection = "MyServiceBus")]
        string myMessage,
        int deliveryCount, // message metadata
        string messageId, // message metadata
        ILogger log)
    {
        log.LogInformation($"Processing message: {messageId}, delivery count: {deliveryCount}");
        log.LogInformation($"Message content: {myMessage}");
        throw new Exception("Intentionally thrown exception.");
    }
}