using System.Net;
using Microsoft.Azure.Cosmos;

namespace AzureWorkshop.CodeSamples.FunctionApps.Repositories.Implementations;

public abstract class CosmosGenericRepositoryBase<TEntity> : ICosmosGenericRepository<TEntity>
{
    protected readonly string _containerName;
    protected readonly Database _cosmosDatabase;

    protected CosmosGenericRepositoryBase(Database cosmosDatabase, string containerName)
    {
        _containerName = containerName;
        _cosmosDatabase = cosmosDatabase;
    }

    public async Task<IEnumerable<TEntity>> ListAsync(string filterClause = default, CancellationToken cancellationToken = default)
    {
        var querySpec = "select * from c";

        if (!string.IsNullOrWhiteSpace(filterClause)) querySpec = $"{querySpec} where {filterClause}";

        using var queryIterator = _cosmosDatabase
            .GetContainer(_containerName)
            .GetItemQueryIterator<TEntity>(new QueryDefinition(querySpec));

        var results = new List<TEntity>();
        while (queryIterator.HasMoreResults)
        {
            var response = await queryIterator.ReadNextAsync(cancellationToken);
            results.AddRange(response.ToList());
        }

        return results;
    }

    public async Task<TEntity> GetAsync(string partitionKey, string id, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _cosmosDatabase
                .GetContainer(_containerName)
                .ReadItemAsync<TEntity>(id, new PartitionKey(partitionKey), cancellationToken: cancellationToken);

            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return default; // i.e. null
        }
    }

    public async Task AddAsync(string partitionKey, TEntity entity, CancellationToken cancellationToken = default)
    {
        await _cosmosDatabase
            .GetContainer(_containerName)
            .CreateItemAsync(entity, new PartitionKey(partitionKey), cancellationToken: cancellationToken);
    }

    public async Task UpsertAsync(string partitionKey, TEntity entity, CancellationToken cancellationToken = default)
    {
        await _cosmosDatabase
            .GetContainer(_containerName)
            .UpsertItemAsync(entity, new PartitionKey(partitionKey), cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(string partitionKey, string id, CancellationToken cancellationToken = default)
    {
        await _cosmosDatabase
            .GetContainer(_containerName)
            .DeleteItemAsync<TEntity>(id, new PartitionKey(partitionKey), cancellationToken: cancellationToken);
    }
}