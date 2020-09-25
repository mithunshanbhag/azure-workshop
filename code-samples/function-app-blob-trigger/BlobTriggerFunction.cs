using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps
{
    public static class BlobTriggerFunction
    {
        [FunctionName("BlobTriggerFunction")]
        public static void Run(
            [BlobTrigger("mycontainer1/{blobName}")] string blobContents,
            string blobName,
            ILogger log)
        {
            log.LogInformation($"Function triggered: BlobTriggerFunction");
            log.LogInformation($"Blob Name: {blobName}");
            log.LogInformation($"Blob Contents: {blobContents}");
        }
    }
}
