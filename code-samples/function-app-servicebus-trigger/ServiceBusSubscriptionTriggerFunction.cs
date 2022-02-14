using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps;

public static class ServiceBusSubscriptionTriggerFunction
{
    [FunctionName("ServiceBusSubscriptionTriggerFunction")]
    public static void Run(
        [ServiceBusTrigger("mytopic1", "mysubscription1")]
        string myMessage,
        int deliveryCount, // message metadata
        string messageId, // message metadata
        ILogger log)
    {
        log.LogInformation($"Processing message: {messageId}, delivery count: {deliveryCount}");
        log.LogInformation($"Message content: {myMessage}");
        log.LogInformation("Finished processing message");
    }
}