namespace AzureWorkshop.CodeSamples.FunctionApps;

public class BlobTriggerFunctionDemo(ILogger<BlobTriggerFunctionDemo> logger)
{
    [Function(nameof(BlobTriggerFunction))]
    public void BlobTriggerFunction(
        [BlobTrigger("mycontainer1/{blobName}")]
        string blobContents,
        string blobName)
    {
        logger.LogInformation($"Blob Name: {blobName}");
        logger.LogInformation($"Blob Contents: {blobContents}");
    }
}