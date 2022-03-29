namespace AzureWorkshop.CodeSamples.FunctionApps.Repositories.Interfaces;

public interface ICosmosGenericRepository<TEntity>
{
    Task<IEnumerable<TEntity>> ListAsync(string filterClause = default, CancellationToken cancellationToken = default);

    Task<TEntity> GetAsync(string partitionKey, string id, CancellationToken cancellationToken = default);

    Task AddAsync(string partitionKey, TEntity entity, CancellationToken cancellationToken = default);

    Task UpsertAsync(string partitionKey, TEntity entity, CancellationToken cancellationToken = default);

    Task DeleteAsync(string partitionKey, string id, CancellationToken cancellationToken = default);
}