namespace AzureWorkshop.CodeSamples.FunctionApps;

public class BlobOutputSdkTypeDemo(ILogger<BlobOutputSdkTypeDemo> logger, BlobServiceClient blobServiceClient)
{
    [Function(nameof(BlobOutputSdkTypeFunction))]
    public async Task BlobOutputSdkTypeFunction(
        [TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
    {
        var containerClient = blobServiceClient.GetBlobContainerClient("mycontainer1");
        await containerClient.CreateIfNotExistsAsync();

        var outputBlobName = DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss");
        var blobClient = containerClient.GetBlobClient(outputBlobName);

        var contentToWrite = $"C# Timer trigger function executed at: {DateTime.Now}";
        logger.LogInformation($"Blob content to be written: {contentToWrite}");

        await blobClient.UploadAsync(new BinaryData(contentToWrite));
    }
}