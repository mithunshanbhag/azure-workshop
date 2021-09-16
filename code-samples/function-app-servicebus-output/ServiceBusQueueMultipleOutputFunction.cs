using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApp
{
    public static class ServiceBusQueueMultipleOutputFunction
    {
        [FunctionName("ServiceBusQueueMultipleOutputFunction")]
        public static async Task Run(
            [TimerTrigger("*/30 * * * * *")] TimerInfo myTimer,
            [ServiceBus("myqueue1")] IAsyncCollector<string> collector,
            ILogger log)
        {
            for (int i = 0; i < 50; i++)
            {
                var message = $"Message #{i} was generated at {DateTime.Now}";
                log.LogInformation($"Writing message: {message}");
                await collector.AddAsync(message);
            }
        }
    }
}
