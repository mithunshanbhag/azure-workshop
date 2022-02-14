using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps;

public static class ServiceBusQueueOutputFunction
{
    [FunctionName("ServiceBusQueueOutputFunction")]
    public static void Run(
        [TimerTrigger("*/30 * * * * *")] TimerInfo myTimer,
        [ServiceBus("myqueue1")] out string myMessage,
        ILogger log)
    {
        myMessage = $"This message was generated at {DateTime.Now}";
        log.LogInformation($"Writing message: {myMessage}");
    }
}