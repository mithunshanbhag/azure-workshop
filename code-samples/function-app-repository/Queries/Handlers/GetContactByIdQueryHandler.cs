namespace AzureWorkshop.CodeSamples.FunctionApps.Queries.Handlers;

public class GetContactByIdQueryHandler : IRequestPreProcessor<GetContactByIdQuery>, IRequestHandler<GetContactByIdQuery, IActionResult>
{
    private readonly IContactService _contactService;

    public GetContactByIdQueryHandler(IContactService contactService)
    {
        _contactService = contactService;
    }

    public async Task<IActionResult> Handle(GetContactByIdQuery query, CancellationToken cancellationToken)
    {
        var contactId = query.ContactId;

        var contactDto = await _contactService.GetByIdAsync(contactId, cancellationToken);

        return new OkObjectResult(contactDto);
    }

    public Task Process(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}