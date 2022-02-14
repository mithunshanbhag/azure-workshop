using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureFundamentalsWorkshop.CodeSamples.CosmosDB;

public interface IContactService
{
    Task<IEnumerable<Contact>> ListContactsAsync();

    Task<Contact> GetContactAsync(string id);

    Task AddContactAsync(Contact contact);

    Task UpdateContactAsync(string id, Contact contact);

    Task DeleteContactAsync(string id);
}