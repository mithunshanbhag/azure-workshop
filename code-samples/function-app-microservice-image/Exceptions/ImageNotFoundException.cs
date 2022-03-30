namespace AzureWorkshop.CodeSamples.FunctionApps.Exceptions;

public class ImageNotFoundException : DomainException
{
    public ImageNotFoundException(Guid contactId)
        : base($"Contact '{contactId}' could not be located.")
    {
    }

    public override IActionResult ToActionResult()
    {
        return new NotFoundObjectResult(Message);
    }
}