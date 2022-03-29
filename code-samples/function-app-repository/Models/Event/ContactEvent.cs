namespace AzureWorkshop.CodeSamples.FunctionApps.Models.Event;

public enum ContactEventType
{
    Created,
    Updated,
    Deleted,
}

public class ContactEvent
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public Guid Id { get; set; }

    public ContactEventType ContactEventType { get; set; }
}