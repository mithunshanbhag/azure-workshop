namespace AzureWorkshop.CodeSamples.FunctionApps.Queries.Handlers;

public class ListContactsQueryHandler : IRequestPreProcessor<ListContactsQuery>, IRequestHandler<ListContactsQuery, IActionResult>
{
    private readonly IContactService _contactService;

    public ListContactsQueryHandler(IContactService contactService)
    {
        _contactService = contactService;
    }

    public async Task<IActionResult> Handle(ListContactsQuery query, CancellationToken cancellationToken)
    {
        var contactDtos = await _contactService.ListContactsAsync(cancellationToken);

        return new OkObjectResult(contactDtos);
    }

    public async Task Process(ListContactsQuery query, CancellationToken cancellationToken)
    {
        var queryValidator = new ListContactsQueryValidator();

        await queryValidator.ValidateAndThrowAsync(query, cancellationToken);
    }
}