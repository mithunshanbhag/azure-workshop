namespace AzureWorkshop.CodeSamples.FunctionApps.Queries.Handlers;

public class GetContactByEmailQueryHandler : IRequestPreProcessor<GetContactByEmailQuery>, IRequestHandler<GetContactByEmailQuery, IActionResult>
{
    private readonly IContactService _contactService;

    public GetContactByEmailQueryHandler(IContactService contactService)
    {
        _contactService = contactService;
    }

    public async Task<IActionResult> Handle(GetContactByEmailQuery query, CancellationToken cancellationToken)
    {
        var email = query.Email;

        var contactDto = await _contactService.GetByEmailAsync(email, cancellationToken);

        return new OkObjectResult(contactDto);
    }

    public async Task Process(GetContactByEmailQuery query, CancellationToken cancellationToken)
    {
        var queryValidator = new GetContactByEmailQueryValidator();

        await queryValidator.ValidateAndThrowAsync(query, cancellationToken);
    }
}