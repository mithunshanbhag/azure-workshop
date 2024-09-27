namespace AzureWorkshop.CodeSamples.FunctionApps;

public class BlobOutputBindingExpressionFunctionDemo(ILogger<BlobOutputBindingExpressionFunctionDemo> logger)
{
    [Function(nameof(BlobOutputBindingExpressionFunction1))]
    [BlobOutput("mycontainer1/foo-{datetime}.txt")]
    public string BlobOutputBindingExpressionFunction1(
        [TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
    {
        var contentToWrite = $"C# Timer trigger function executed at: {DateTime.Now}";

        logger.LogInformation($"Blob content to be written: {contentToWrite}");

        // Blob output
        return contentToWrite;
    }

    [Function(nameof(BlobOutputBindingExpressionFunction2))]
    [BlobOutput("mycontainer1/foo-{rand-guid}.txt")]
    public string BlobOutputBindingExpressionFunction2(
        [TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
    {
        var contentToWrite = $"C# Timer trigger function executed at: {DateTime.Now}";

        logger.LogInformation($"Blob content to be written: {contentToWrite}");

        // Blob output
        return contentToWrite;
    }
}