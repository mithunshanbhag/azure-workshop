//namespace AzureWorkshop.CodeSamples.FunctionApps;

//public class BlobOutputRuntimeBinderFunctionDemo(ILogger<BlobOutputRuntimeBinderFunctionDemo> logger)
//{
//    [Function(nameof(BlobOutputRuntimeBinderFunctionDemo))]
//    public async Task BlobOutputRuntimeBinderFunctionDemo(
//        [TimerTrigger("0 */1 * * * *")] TimerInfo myTimer,
//        Binder binder,
//        ILogger log)
//    {
//        log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

//        var outputContainerName = "mycontainer1";
//        var outputBlobName = DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss");
//        var outputBlobAttr = new BlobAttribute($"{outputContainerName}/{outputBlobName}", FileAccess.Write);
//        await using var outputFile = await binder.BindAsync<TextWriter>(outputBlobAttr);
//        await outputFile.WriteAsync($"processed at {DateTime.UtcNow:s}");
//    }
//}