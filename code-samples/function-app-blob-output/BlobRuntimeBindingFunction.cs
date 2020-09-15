using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps
{
    public static class BlobRuntimeBindingFunction
    {
        [FunctionName("BlobRuntimeBindingFunction")]
        public static async Task Run(
            [TimerTrigger("0 */1 * * * *")] TimerInfo myTimer,
            Binder binder,
            ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var outputContainerName = "mycontainer";
            var outputBlobName = DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss");
            var outputBlobAttr = new BlobAttribute($"{outputContainerName}/{outputBlobName}", FileAccess.Write);
            using (var outputFile = await binder.BindAsync<TextWriter>(outputBlobAttr))
            {
                await outputFile.WriteAsync($"processed at {DateTime.UtcNow.ToString("s")}");
            }
        }
    }
}
