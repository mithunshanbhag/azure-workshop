namespace AzureWorkshop.CodeSamples.FunctionApps;

public class BlobInputBindingFunctionDemo(ILogger<BlobInputBindingFunctionDemo> logger)
{
    [Function(nameof(BlobInputBindingFunction))]
    public void BlobInputBindingFunction(
        [TimerTrigger("*/30 * * * * *")] TimerInfo myTimer,
        [BlobInput("mycontainer1/inputfile.txt")]
        string blobContents)
    {
        logger.LogInformation($"Blob Contents: {blobContents}");
    }
}