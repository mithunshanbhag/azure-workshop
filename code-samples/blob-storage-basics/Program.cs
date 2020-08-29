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
            Console.WriteLine($"Enumerating containers in storage account '{this.serviceClient.AccountName}'");
            foreach (var container in this.serviceClient.GetBlobContainers())
            {
                Console.WriteLine($"\t{container.Name}");
            }
        }

        private void EnumerateContainersAnonymously()
        {
            var anonServiceClient = new BlobServiceClient(this.serviceClient.Uri);
            Console.WriteLine($"Anonymously enumerating containers in storage account '{this.serviceClient.AccountName}'");
            try
            {
                foreach (var container in anonServiceClient.GetBlobContainers())
                {
                    Console.WriteLine($"\t{container.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tFailed with {ex.GetType().ToString()}");
            }
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

        private void EnumerateBlobs(BlobContainerClient container)
        {
            Console.WriteLine($"Enumerating blobs in container '{container.Name}'");
            foreach (var blob in container.GetBlobs())
            {
                Console.WriteLine($"\t{blob.Name}");
            }
        }

        private void EnumerateBlobsAnonymously(BlobContainerClient container)
        {
            var anonContainerClient = new BlobContainerClient(container.Uri);
            Console.WriteLine($"Anonymously enumerating blobs in container '{container.Name}'");
            try
            {
                foreach (var blob in anonContainerClient.GetBlobs())
                {
                    Console.WriteLine($"\t{blob.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tFailed with {ex.GetType().ToString()}");
            }
        }

        static async Task Main(string[] args)
        {
            var demo = new BlobStorageBasics();

            try
            {
                foreach (var container in await demo.CreateContainersAsync())
                {
                    await demo.UploadBlobsAsync(container);

                    demo.EnumerateBlobs(container);
                    demo.EnumerateBlobsAnonymously(container);
                }

                demo.EnumerateContainers();
                demo.EnumerateContainersAnonymously();
            }
            finally
            {
                await demo.DeleteContainersAsync();
            }
        }
    }
}
