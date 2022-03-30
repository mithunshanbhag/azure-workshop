namespace AzureWorkshop.CodeSamples.FunctionApps.Services.Implementations;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;

    private readonly IContactEventStream _contactEventStream;

    private readonly IMapper _mapper;

    public ContactService(IContactRepository contactRepository, IContactEventStream contactEventStream, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _contactEventStream = contactEventStream;
        _mapper = mapper;
    }

    public async Task<ContactDto> CreateAsync(ContactDto newContactDto, CancellationToken cancellationToken = default)
    {
        var newContactDao = _mapper.Map<ContactDao>(newContactDto);

        newContactDao.id = Guid.NewGuid(); // always auto-generate a new id

        await _contactRepository.AddAsync(newContactDao.id.ToString(), newContactDao, cancellationToken);

        var createdContactDto = _mapper.Map<ContactDto>(newContactDao);
        return createdContactDto;
    }

    public async Task UpdateAsync(Guid contactId, ContactDto newContactDto, CancellationToken cancellationToken = default)
    {
        var newContactDao = _mapper.Map<ContactDao>(newContactDto);

        await _contactRepository.UpsertAsync(contactId.ToString(), newContactDao, cancellationToken);
    }

    public async Task DeleteAsync(Guid contactId, CancellationToken cancellationToken = default)
    {
        await _contactRepository.DeleteAsync(contactId.ToString(), contactId.ToString(), cancellationToken);
    }

    public async Task<ContactDto> GetByIdAsync(Guid contactId, CancellationToken cancellationToken = default)
    {
        var contactDao = await _contactRepository.GetAsync(contactId.ToString(), contactId.ToString(), cancellationToken);

        if (contactDao is null) throw new ContactNotFoundException(contactId);

        var contactDto = _mapper.Map<ContactDto>(contactDao);

        return contactDto;
    }

    public Task<ContactDto> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ContactDto>> ListContactsAsync(CancellationToken cancellationToken = default)
    {
        var contactDaos = await _contactRepository.ListAsync(cancellationToken: cancellationToken);

        var contactDtos = _mapper.Map<IEnumerable<ContactDto>>(contactDaos);

        return contactDtos;
    }
}