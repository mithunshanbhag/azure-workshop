using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps;

public static class ServiceBusQueueMultipleOutputFunction
{
    [FunctionName("ServiceBusQueueMultipleOutputFunction")]
    public static async Task Run(
        [TimerTrigger("*/30 * * * * *")] TimerInfo myTimer,
        [ServiceBus("myqueue1")] IAsyncCollector<string> collector,
        ILogger log)
    {
        for (var i = 0; i < 50; i++)
        {
            var message = $"Message #{i} was generated at {DateTime.Now}";
            log.LogInformation($"Writing message: {message}");
            await collector.AddAsync(message);
        }
    }
}