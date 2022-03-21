using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace AzureWorkshop.CodeSamples.BlobStorage;

public class BlobStorageSas
{
    private readonly string _connectionString = "<@replace-with-endpoint-uri>";
    private readonly BlobServiceClient _serviceClient;

    private BlobStorageSas()
    {
        _serviceClient = new BlobServiceClient(_connectionString);
    }

    private async Task DeleteContainersAsync()
    {
        Console.WriteLine($"Deleting containers in storage account '{_serviceClient.AccountName}'");
        foreach (var container in _serviceClient.GetBlobContainers())
        {
            await _serviceClient.DeleteBlobContainerAsync(container.Name);
            Console.WriteLine($"\t{container.Name}");
        }
    }

    private async Task<BlobContainerClient> CreateContainerAsync()
    {
        Console.WriteLine($"Creating container in storage account '{_serviceClient.AccountName}'");
        var accessType = PublicAccessType.BlobContainer;
        var response = await _serviceClient.CreateBlobContainerAsync($"my-container-access-{accessType.ToString().ToLowerInvariant()}", accessType);
        var container = response?.Value;
        Console.WriteLine($"\t{container?.Name}");
        return container;
    }

    private async Task UploadBlobsAsync(BlobContainerClient container)
    {
        Console.WriteLine($"Uploading files to container '{container.Name}'");
        foreach (var fileName in new List<string> {"sample.csv", "sample.json", "sample.txt"})
        {
            await container.UploadBlobAsync(fileName, File.OpenRead($"./{fileName}"));
            Console.WriteLine($"\t{fileName}");
        }
    }

    private static async Task Main()
    {
        var demo = new BlobStorageSas();

        try
        {
            var container = await demo.CreateContainerAsync();
            await demo.UploadBlobsAsync(container);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception Caught: ${ex.Message}");
        }
        finally
        {
            await demo.DeleteContainersAsync();
        }
    }
}