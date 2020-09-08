using System;
using Azure.Storage.Blobs;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using System.Collections.Generic;
using System.IO;

namespace AzureFundamentalsWorkshop.CodeSamples.BlobStorage
{
    public class BlobStorageSAS
    {
        private readonly string connectionString = "<@replace-with-connection-string>";
        private readonly BlobServiceClient serviceClient;

        BlobStorageSAS()
        {
            this.serviceClient = new BlobServiceClient(this.connectionString);
        }

        private async Task DeleteContainersAsync()
        {
            Console.WriteLine($"Deleting containers in storage account '{this.serviceClient.AccountName}'");
            foreach (var container in this.serviceClient.GetBlobContainers())
            {
                await this.serviceClient.DeleteBlobContainerAsync(container.Name);
                Console.WriteLine($"\t{container.Name}");
            }
        }

        private async Task<BlobContainerClient> CreateContainerAsync()
        {
            Console.WriteLine($"Creating container in storage account '{this.serviceClient.AccountName}'");
            var accessType = PublicAccessType.BlobContainer;
            var response = (await this.serviceClient.CreateBlobContainerAsync($"my-container-access-{accessType.ToString().ToLowerInvariant()}", accessType));
            var container = response?.Value;
            Console.WriteLine($"\t{container.Name}");
            return container;
        }

        private async Task UploadBlobsAsync(BlobContainerClient container)
        {
            Console.WriteLine($"Uploading files to container '{container.Name}'");
            foreach (var fileName in new List<string> { "sample.csv", "sample.json", "sample.txt" })
            {
                await container.UploadBlobAsync(fileName, File.OpenRead($"./{fileName}"));
                Console.WriteLine($"\t{fileName}");
            }
        }

        static async Task Main(string[] args)
        {
            var demo = new BlobStorageSAS();

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
}
