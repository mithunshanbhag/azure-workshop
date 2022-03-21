using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureWorkshop.CodeSamples.FunctionApps;

public static class BlobTriggerFunction
{
    [FunctionName("BlobTriggerFunction")]
    public static void Run(
        [BlobTrigger("mycontainer1/{blobName}")]
        string blobContents,
        string blobName,
        ILogger log)
    {
        log.LogInformation("Function triggered: BlobTriggerFunction");
        log.LogInformation($"Blob Name: {blobName}");
        log.LogInformation($"Blob Contents: {blobContents}");
    }
}