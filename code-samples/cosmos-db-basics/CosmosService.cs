namespace AzureFundamentalsWorkshop.CodeSamples.CosmosDB
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Fluent;

    public class CosmosService : ICosmosService
    {
        private CosmosClient cosmosClient;
        private Database database;
        private Container container;

        private readonly string databaseName = "contactsdb";
        private readonly string containerName = "contactscontainer";


        public async Task InitializeAsync(string endpointUrl, string accountKey)
        {
            this.cosmosClient = new CosmosClient(endpointUrl, accountKey);

            var dbResponse = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(this.databaseName);
            this.database = dbResponse.Database;
            Console.WriteLine($"Fetched database: {this.databaseName}");

            var containerResponse = await this.database.CreateContainerIfNotExistsAsync(this.containerName, "/id");
            this.container = containerResponse.Container;
            Console.WriteLine($"Fetched container: {this.containerName}");
        }

        public async Task AddContactAsync(Contact contact)
        {
            await this.container.CreateItemAsync<Contact>(contact, new PartitionKey(contact.Id));
            Console.WriteLine($"added contact: id={contact.Id}");
        }

        public async Task DeleteContactAsync(string id)
        {
            await this.container.DeleteItemAsync<Contact>(id, new PartitionKey(id));
            Console.WriteLine($"deleted contact: id={id}");
        }

        public async Task<Contact> GetContactAsync(string id)
        {
            try
            {
                ItemResponse<Contact> response = await this.container.ReadItemAsync<Contact>(id, new PartitionKey(id));
                Console.WriteLine($"fetched contact: id={id}");

                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Contact>> ListContactsAsync()
        {
            var query = this.container.GetItemQueryIterator<Contact>(new QueryDefinition("select * from c"));
            List<Contact> results = new List<Contact>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateContactAsync(string id, Contact contact)
        {
            await this.container.UpsertItemAsync<Contact>(contact, new PartitionKey(id));
            Console.WriteLine($"updated contact: id={id}");
        }
    }
}