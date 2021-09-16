using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps
{
    public static class BlobOutputBindingExpressionFunction
    {
        [FunctionName("BlobOutputBindingExpressionFunction")]
        public static void Run(
            [TimerTrigger("0 */1 * * * *")] TimerInfo myTimer,
            [Blob("mycontainer1/foo-{datetime}.txt", FileAccess.Write)] out string contentToWrite1,
            [Blob("mycontainer1/bar-{rand-guid}.txt", FileAccess.Write)] out string contentToWrite2,
            ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            contentToWrite1 = contentToWrite2 = $"C# Timer trigger function executed at: {DateTime.Now}";
        }
    }
}
