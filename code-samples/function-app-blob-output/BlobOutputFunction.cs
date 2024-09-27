namespace AzureWorkshop.CodeSamples.FunctionApps;

public class BlobOutputFunctionDemo(ILogger<BlobOutputFunctionDemo> logger)
{
    [Function(nameof(BlobOutputFunction))]
    [BlobOutput("mycontainer1/foo.txt")]
    public string BlobOutputFunction(
        [TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
    {
        var contentToWrite = $"C# Timer trigger function executed at: {DateTime.Now}";

        logger.LogInformation($"Blob content to be written: {contentToWrite}");

        // Blob output
        return contentToWrite;
    }
}