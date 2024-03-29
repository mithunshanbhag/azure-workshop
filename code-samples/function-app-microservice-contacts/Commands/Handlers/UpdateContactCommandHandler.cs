﻿namespace AzureWorkshop.CodeSamples.FunctionApps.Commands.Handlers;

public class UpdateContactCommandHandler : IRequestPreProcessor<UpdateContactCommand>, IRequestHandler<UpdateContactCommand, IActionResult>
{
    private readonly IContactService _contactService;

    public UpdateContactCommandHandler(IContactService contactService)
    {
        _contactService = contactService;
    }

    public async Task<IActionResult> Handle(UpdateContactCommand command, CancellationToken cancellationToken)
    {
        var contactId = command.ContactId;
        var newContactDto = command.NewContactDto;

        await _contactService.UpdateAsync(contactId, newContactDto, cancellationToken);

        return new OkResult();
    }

    public async Task Process(UpdateContactCommand command, CancellationToken cancellationToken)
    {
        var commandValidator = new UpdateContactCommandValidator();

        await commandValidator.ValidateAndThrowAsync(command, cancellationToken);
    }
}