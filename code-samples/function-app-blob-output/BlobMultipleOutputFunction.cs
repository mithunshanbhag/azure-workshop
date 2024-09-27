namespace AzureWorkshop.CodeSamples.FunctionApps;

public class MultipleOutputType
{
    [BlobOutput("mycontainer1/foo1.txt")] public string Output1 { get; set; }

    [BlobOutput("mycontainer1/foo2.txt")] public string Output2 { get; set; }

    // Note: You can also include other output bindings here like service bus messages etc (i.e. not just blob output bindings)
}

public class BlobMultipleOutputFunctionDemo(ILogger<BlobMultipleOutputFunctionDemo> logger)
{
    [Function(nameof(BlobMultipleOutputFunction))]
    public MultipleOutputType BlobMultipleOutputFunction(
        [TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
    {
        var contentToWrite = $"C# Timer trigger function executed at: {DateTime.Now}";

        logger.LogInformation($"Blob content to be written: {contentToWrite}");

        // Blob output
        return new MultipleOutputType
        {
            Output1 = contentToWrite,
            Output2 = contentToWrite
        };
    }
}