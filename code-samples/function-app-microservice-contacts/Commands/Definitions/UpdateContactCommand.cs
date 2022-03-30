namespace AzureWorkshop.CodeSamples.FunctionApps.Commands.Definitions;

public class UpdateContactCommand : IRequest<IActionResult>
{
    public Guid ContactId { get; set; }

    public ContactDto NewContactDto { get; set; }
}