namespace AzureWorkshop.CodeSamples.FunctionApps.Commands.Handlers;

public class CreateContactCommandHandler : IRequestPreProcessor<CreateContactCommand>, IRequestHandler<CreateContactCommand, IActionResult>
{
    private readonly IContactService _contactService;

    public CreateContactCommandHandler(IContactService contactService)
    {
        _contactService = contactService;
    }

    public async Task<IActionResult> Handle(CreateContactCommand command, CancellationToken cancellationToken)
    {
        var newContactDto = command.NewContactDto;

        var createdContactDto = await _contactService.CreateAsync(newContactDto, cancellationToken);

        return new OkObjectResult(createdContactDto);
    }

    public async Task Process(CreateContactCommand command, CancellationToken cancellationToken)
    {
        var commandValidator = new CreateContactCommandValidator();

        await commandValidator.ValidateAndThrowAsync(command, cancellationToken);
    }
}