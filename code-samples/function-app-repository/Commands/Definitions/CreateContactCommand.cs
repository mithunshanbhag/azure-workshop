namespace AzureWorkshop.CodeSamples.FunctionApps.Commands.Definitions;

public class CreateContactCommand : IRequest<IActionResult>
{
    public ContactDto NewContactDto { get; set; }
}