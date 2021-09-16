using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApp
{
    public static class ServiceBusQueueOutputFunction
    {
        [FunctionName("ServiceBusQueueOutputFunction")]
        public static void Run(
            [TimerTrigger("*/30 * * * * *")]TimerInfo myTimer,
            [ServiceBus("myqueue1")] out string myMessage,
            ILogger log)
        {
            myMessage = $"This message was generated at {DateTime.Now}";
            log.LogInformation($"Writing message: {myMessage}");
        }
    }
}
