using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace AzureWorkshop.CodeSamples.BlobStorage;

public class BlobStorageBasics
{
    private readonly string _connectionString = "<@replace-with-endpoint-uri>";
    private readonly BlobServiceClient _serviceClient;

    private BlobStorageBasics()
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

    private async Task<List<BlobContainerClient>> CreateContainersAsync()
    {
        var containers = new List<BlobContainerClient>();
        foreach (PublicAccessType accessType in Enum.GetValues(typeof(PublicAccessType)))
        {
            var response = await _serviceClient.CreateBlobContainerAsync($"my-container-access-{accessType.ToString().ToLowerInvariant()}", accessType);

            var container = response?.Value;
            if (container != null) containers.Add(container);
        }

        return containers;
    }

    private async Task EnumerateContainers()
    {
        Console.WriteLine($"Enumerating containers in storage account '{_serviceClient.AccountName}'");
        await foreach (var container in _serviceClient.GetBlobContainersAsync()) Console.WriteLine($"\t{container.Name}");
    }

    private async Task EnumerateContainersAnonymously()
    {
        var anonServiceClient = new BlobServiceClient(_serviceClient.Uri);
        Console.WriteLine($"Anonymously enumerating containers in storage account '{_serviceClient.AccountName}'");
        try
        {
            await foreach (var container in anonServiceClient.GetBlobContainersAsync()) Console.WriteLine($"\t{container.Name}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\tFailed with {ex.GetType()}");
        }
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

    private async Task EnumerateBlobs(BlobContainerClient container)
    {
        Console.WriteLine($"Enumerating blobs in container '{container.Name}'");
        await foreach (var blob in container.GetBlobsAsync()) Console.WriteLine($"\t{blob.Name}");
    }

    private async Task EnumerateBlobsAnonymously(BlobContainerClient container)
    {
        var anonContainerClient = new BlobContainerClient(container.Uri);
        Console.WriteLine($"Anonymously enumerating blobs in container '{container.Name}'");
        try
        {
            await foreach (var blob in anonContainerClient.GetBlobsAsync()) Console.WriteLine($"\t{blob.Name}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\tFailed with {ex.GetType()}");
        }
    }

    private static async Task Main()
    {
        var demo = new BlobStorageBasics();


        try
        {
            foreach (var container in await demo.CreateContainersAsync())
            {
                await demo.UploadBlobsAsync(container);

                await demo.EnumerateBlobs(container);
                await demo.EnumerateBlobsAnonymously(container);
            }

            await demo.EnumerateContainers();
            await demo.EnumerateContainersAnonymously();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception Caught: ${ex.Message}");
        }
        finally
        {
            //await demo.DeleteContainersAsync();
        }
    }
}