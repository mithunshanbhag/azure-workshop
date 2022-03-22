namespace AzureWorkshop.CodeSamples.FunctionApps.Commands.Handlers;

public class DeleteContactCommandHandler : IRequestPreProcessor<DeleteContactCommand>, IRequestHandler<DeleteContactCommand, IActionResult>
{
    private readonly IContactService _contactService;

    public DeleteContactCommandHandler(IContactService contactService)
    {
        _contactService = contactService;
    }

    public async Task<IActionResult> Handle(DeleteContactCommand command, CancellationToken cancellationToken)
    {
        var contactId = command.ContactId;

        await _contactService.DeleteAsync(contactId, cancellationToken);

        return new OkResult();
    }

    public Task Process(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}