using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace function_app_mixed
{
    public static class BlobTriggeredFunction
    {
        // [Disable]
        [FunctionName("BlobTriggeredFunction")]
        public static void Run(
            [BlobTrigger("mycontainer/{name}")] Stream myBlob,
            string name,
            ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
