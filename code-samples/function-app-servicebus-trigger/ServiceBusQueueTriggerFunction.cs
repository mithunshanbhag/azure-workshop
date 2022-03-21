using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureWorkshop.CodeSamples.FunctionApps;

public static class ServiceBusQueueTriggerFunction
{
    [FunctionName("ServiceBusQueueTriggerFunction")]
    public static void Run(
        [ServiceBusTrigger("myqueue1")] string myMessage,
        int deliveryCount, // message metadata
        string messageId, // message metadata
        ILogger log)
    {
        log.LogInformation($"Processing message: {messageId}, delivery count: {deliveryCount}");
        log.LogInformation($"Message content: {myMessage}");
        log.LogInformation("Finished processing message");
    }
}