using Microsoft.Azure.Cosmos;

namespace AzureWorkshop.CodeSamples.FunctionApps.Repositories.Implementations;

public class ContactRepository : CosmosGenericRepositoryBase<ContactDao>, IContactRepository
{
    public ContactRepository(Database cosmosDatabase) : base(cosmosDatabase, CosmosConstants.ContactsContainerName)
    {
    }
}