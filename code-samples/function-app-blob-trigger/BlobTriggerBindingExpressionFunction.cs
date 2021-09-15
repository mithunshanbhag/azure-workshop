using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps
{
    public static class BlobTriggerBindingExpressionFunction
    {
        #region filenames

        // blob filename (full name including extension)
        [FunctionName("BlobTriggerBindingExpressionDemo1")]
        public static void RunBlobTriggerBindingExpressionDemo1(
            [BlobTrigger("mycontainer1/{blobFullName}")] string blobContents,
            string blobFullName,
            ILogger log)
        {
            log.LogInformation($"Function triggered: BlobTriggerBindingExpressionDemo1");
            log.LogInformation($"Blob Name: {blobFullName}");
            log.LogInformation($"Blob Content: {blobContents}");
        }

        // blob filename and extension
        [FunctionName("BlobTriggerBindingExpressionDemo2")]
        public static void RunBlobTriggerBindingExpressionDemo2(
            [BlobTrigger("mycontainer1/{blobName}.{blobExt}")] string blobContents,
            string blobName,
            string blobExt,
            ILogger log)
        {
            log.LogInformation($"Function triggered: BlobBindingExpressionFileName");
            log.LogInformation($"Blob Name: {blobName}.{blobExt}");
            log.LogInformation($"Blob Content: {blobContents}");
        }

        // blob filename (pattern match)
        [FunctionName("BlobTriggerBindingExpressionDemo3")]
        public static void RunBlobTriggerBindingExpressionDemo3(
            [BlobTrigger("mycontainer1/{blobName}.txt")] string blobContents,
            string blobName,
            ILogger log)
        {
            log.LogInformation($"Function triggered: RunBlobTriggerBindingExpressionDemo3");
            log.LogInformation($"Blob Name (minus extension): {blobName}");
            log.LogInformation($"Blob Content: {blobContents}");
        }

        // blob filename (pattern match)
        [FunctionName("BlobTriggerBindingExpressionDemo4")]
        public static void BlobTriggerBindingExpressionDemo4(
            [BlobTrigger("mycontainer1/{blobNamePart1}-{blobNamePart2}.txt")] string blobContents,
            string blobNamePart1,
            string blobNamePart2,
            ILogger log)
        {
            log.LogInformation($"Function triggered: BlobTriggerBindingExpressionDemo4");
            log.LogInformation($"Blob Name (minus extension): {blobNamePart1}-{blobNamePart2}.txt");
            log.LogInformation($"Blob Content: {blobContents}");
        }

        #endregion // filenames

        #region metadata

        [FunctionName("BlobTriggerBindingExpressionDemo5")]
        public static void BlobTriggerBindingExpressionDemo5(
            [BlobTrigger("mycontainer1/{blobName}")] string blobContents,
            string blobName,
            string blobTrigger, // note: param name must match specs
            Uri uri,
            ILogger log)
        {
            log.LogInformation($"Function triggered: BlobTriggerBindingExpressionDemo5");
            log.LogInformation($"Blob Name: {blobName}");
            log.LogInformation($"Blob Path: {blobTrigger}");
            log.LogInformation($"Blob Uri: {uri.ToString()}");
            log.LogInformation($"Blob Content: {blobContents}");
        }

        #endregion // metadata
    }
}
