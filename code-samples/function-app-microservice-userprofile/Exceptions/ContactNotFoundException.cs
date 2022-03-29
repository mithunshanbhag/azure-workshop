namespace AzureWorkshop.CodeSamples.FunctionApps.Exceptions;

public class ContactNotFoundException : DomainException
{
    public ContactNotFoundException(Guid contactId)
        : base($"Contact '{contactId}' could not be located.")
    {
    }

    public override IActionResult ToActionResult()
    {
        return new NotFoundObjectResult(Message);
    }
}