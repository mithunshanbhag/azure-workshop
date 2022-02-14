using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps;

public static class BlobInputBindingFunction
{
    [FunctionName("BlobInputBindingFunction")]
    public static void Run(
        [TimerTrigger("*/30 * * * * *")] TimerInfo myTimer,
        [Blob("mycontainer1/inputfile.txt", FileAccess.Read)]
        string blobContents,
        ILogger log)
    {
        log.LogInformation("Function triggered: BlobTriggerFunction");
        log.LogInformation($"Blob Contents: {blobContents}");
    }
}