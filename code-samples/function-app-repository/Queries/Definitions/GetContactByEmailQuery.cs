namespace AzureWorkshop.CodeSamples.FunctionApps.Queries.Definitions;

public class GetContactByEmailQuery : IRequest<IActionResult>
{
    public string Email { get; set; }
}