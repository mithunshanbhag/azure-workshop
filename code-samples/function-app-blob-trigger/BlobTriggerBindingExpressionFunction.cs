namespace AzureWorkshop.CodeSamples.FunctionApps;

public class BlobTriggerBindingExpressionDemo(ILogger<BlobTriggerBindingExpressionDemo> logger)
{
    // blob filename(full name including extension)
    [Function(nameof(BlobTriggerBindingExpressionDemo1))]
    public void BlobTriggerBindingExpressionDemo1(
        [BlobTrigger("mycontainer1/{blobFullName}")]
        string blobContents,
        string blobFullName)
    {
        logger.LogInformation($"Blob Name: {blobFullName}");
        logger.LogInformation($"Blob Content: {blobContents}");
    }

    // blob filename and extension
    [Function(nameof(BlobTriggerBindingExpressionDemo2))]
    public void BlobTriggerBindingExpressionDemo2(
        [BlobTrigger("mycontainer1/{blobName}.{blobExt}")]
        string blobContents,
        string blobName,
        string blobExt)
    {
        logger.LogInformation($"Blob Name: {blobName}.{blobExt}");
        logger.LogInformation($"Blob Content: {blobContents}");
    }

    //blob filename(pattern match)
    [Function(nameof(BlobTriggerBindingExpressionDemo3))]
    public void BlobTriggerBindingExpressionDemo3(
        [BlobTrigger("mycontainer1/{blobName}.txt")]
        string blobContents,
        string blobName)
    {
        logger.LogInformation($"Blob Name (minus extension): {blobName}");
        logger.LogInformation($"Blob Content: {blobContents}");
    }

    // blob filename (pattern match)
    [Function(nameof(BlobTriggerBindingExpressionDemo4))]
    public void BlobTriggerBindingExpressionDemo4(
        [BlobTrigger("mycontainer1/{blobNamePart1}-{blobNamePart2}.txt")]
        string blobContents,
        string blobNamePart1,
        string blobNamePart2)
    {
        logger.LogInformation($"Blob Name (minus extension): {blobNamePart1}-{blobNamePart2}.txt");
        logger.LogInformation($"Blob Content: {blobContents}");
    }

    // with blob metadata
    [Function(nameof(BlobTriggerBindingExpressionDemo5))]
    public void BlobTriggerBindingExpressionDemo5(
        [BlobTrigger("mycontainer1/{blobName}")]
        string blobContents,
        string blobName,
        string blobTrigger, // note: param name must match specs
        Uri uri)
    {
        logger.LogInformation($"Blob Name: {blobName}");
        logger.LogInformation($"Blob Path: {blobTrigger}");
        logger.LogInformation($"Blob Uri: {uri}");
        logger.LogInformation($"Blob Content: {blobContents}");
    }
}