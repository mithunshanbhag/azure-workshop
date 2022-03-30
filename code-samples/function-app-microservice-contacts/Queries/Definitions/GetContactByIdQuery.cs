namespace AzureWorkshop.CodeSamples.FunctionApps.Queries.Definitions;

public class GetContactByIdQuery : IRequest<IActionResult>
{
    public Guid ContactId { get; set; }
}