using System;
using Azure.Storage.Blobs;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using System.Collections.Generic;
using System.IO;

namespace AzureFundamentalsWorkshop.CodeSamples.BlobStorage
{
    public class BlobStorageBasics
    {
        private readonly string connectionString = "DefaultEndpointsProtocol=https;AccountName=satempdeleteme;AccountKey=E1IStWNaJ53FDfK9+2MXWaUX6qYZceaASEjzlX/KwK0OT+QwEvI/ktrXVuckMrc+73nZP561nKH546Qkz0zQ0A==;EndpointSuffix=core.windows.net";
        private readonly BlobServiceClient serviceClient;

        BlobStorageBasics()
        {
            this.serviceClient = new BlobServiceClient(this.connectionString);
        }

        private async Task DeleteContainersAsync()
        {
            foreach (var container in this.serviceClient.GetBlobContainers())
            {
                Console.WriteLine($"Deleting container: {container.Name}");
                await this.serviceClient.DeleteBlobContainerAsync(container.Name);
                Console.WriteLine("OK");
            }
        }

        private async Task<List<BlobContainerClient>> CreateContainersAsync()
        {
            var containers = new List<BlobContainerClient>();
            foreach (PublicAccessType accessType in Enum.GetValues(typeof(PublicAccessType)))
            {
                var response = (await this.serviceClient.CreateBlobContainerAsync($"my-container-access-{accessType.ToString().ToLowerInvariant()}", accessType));

                var container = response?.Value;
                if (container != null)
                {
                    containers.Add(container);
                }
            }
            return containers;
        }

        private void EnumerateContainers()
        {
            foreach (var container in this.serviceClient.GetBlobContainers())
            {
                Console.WriteLine($"Enumerating container '{container.Name}' in storage account '${this.serviceClient.AccountName}'");
                Console.WriteLine("OK");
            }
        }

        private void EnumerateContainersAnonymously()
        {
            var anonServiceClient = new BlobServiceClient(this.serviceClient.Uri);
            foreach(var container in anonServiceClient.GetBlobContainers())
            {
                Console.WriteLine($"Anonymously enumerating container '{container.Name}' in storage account '${this.serviceClient.AccountName}'");
                Console.WriteLine("OK");
            }
        }

        private async Task UploadBlobsAsync(BlobContainerClient container)
        {
            foreach (var fileName in new List<string> { "sample.csv", "sample.json", "sample.txt" })
            {
                Console.WriteLine($"Uploading file '{fileName}' to container '${container.Name}'");
                await container.UploadBlobAsync(fileName, File.OpenRead($"./{fileName}"));
                Console.WriteLine("OK");
            }
        }

        private void EnumerateBlobs(BlobContainerClient container)
        {
            foreach (var blob in container.GetBlobs())
            {
                Console.WriteLine($"Enumerating blob '{blob.Name}' in container '${container.Name}'");
                Console.WriteLine("OK");
            }
        }

        static async Task Main(string[] args)
        {
            var demo = new BlobStorageBasics();

            foreach (var container in await demo.CreateContainersAsync())
            {
                await demo.UploadBlobsAsync(container);
                demo.EnumerateBlobs(container);
            }

            demo.EnumerateContainers();
            demo.EnumerateContainersAnonymously();

            await demo.DeleteContainersAsync();
        }
    }
}
