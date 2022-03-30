namespace AzureWorkshop.CodeSamples.FunctionApps.Services.Interfaces;

public interface IContactService
{
    Task<ContactDto> CreateAsync(ContactDto newContactDto, CancellationToken cancellationToken = default);

    Task UpdateAsync(Guid contactId, ContactDto newContactDto, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid contactId, CancellationToken cancellationToken = default);

    Task<ContactDto> GetByIdAsync(Guid contactId, CancellationToken cancellationToken = default);

    Task<ContactDto> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    Task<IEnumerable<ContactDto>> ListContactsAsync(CancellationToken cancellationToken = default);
}