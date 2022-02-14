using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace AzureFundamentalsWorkshop.CodeSamples.CosmosDB;

public class CosmosService : IContactService
{
    private readonly string _containerName = "contactscontainer";
    private readonly string _databaseName = "contactsdb";

    private Container _container;
    private CosmosClient _cosmosClient;
    private Database _database;

    public async Task AddContactAsync(Contact contact)
    {
        await _container.CreateItemAsync(contact, new PartitionKey(contact.Id));
        Console.WriteLine($"added contact: id={contact.Id}");
    }

    public async Task DeleteContactAsync(string id)
    {
        await _container.DeleteItemAsync<Contact>(id, new PartitionKey(id));
        Console.WriteLine($"deleted contact: id={id}");
    }

    public async Task<Contact> GetContactAsync(string id)
    {
        try
        {
            var response = await _container.ReadItemAsync<Contact>(id, new PartitionKey(id));
            Console.WriteLine($"fetched contact: id={id}");

            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Contact>> ListContactsAsync()
    {
        var query = _container.GetItemQueryIterator<Contact>(new QueryDefinition("select * from c"));
        var results = new List<Contact>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            results.AddRange(response.ToList());
        }

        return results;
    }

    public async Task UpdateContactAsync(string id, Contact contact)
    {
        await _container.UpsertItemAsync(contact, new PartitionKey(id));
        Console.WriteLine($"updated contact: id={id}");
    }


    public async Task InitializeAsync(string endpointUrl, string accountKey)
    {
        _cosmosClient = new CosmosClient(endpointUrl, accountKey);

        var dbResponse = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_databaseName);
        _database = dbResponse.Database;
        Console.WriteLine($"Fetched database: {_databaseName}");

        var containerResponse = await _database.CreateContainerIfNotExistsAsync(_containerName, "/id");
        _container = containerResponse.Container;
        Console.WriteLine($"Fetched container: {_containerName}");
    }
}