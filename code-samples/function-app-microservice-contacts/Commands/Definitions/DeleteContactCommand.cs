namespace AzureWorkshop.CodeSamples.FunctionApps.Commands.Definitions;

public class DeleteContactCommand : IRequest<IActionResult>
{
    public Guid ContactId { get; set; }
}