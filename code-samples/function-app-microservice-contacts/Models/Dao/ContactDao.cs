namespace AzureWorkshop.CodeSamples.FunctionApps.Models.Dao;

public class ContactDao
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    /// <remarks>
    ///     Unfortunately System.Text.Json.JsonPropertyName attribute does not work correctly with CosmosDB SDK yet.
    ///     So, we'll just use camel/lower case 'id' instead of pascal case 'Id'.
    ///     Details: https://www.koskila.net/system-text-json-jsonpropertyname-not-working-for-cosmosdb-in-net-core-5/
    /// </remarks>
    public Guid id { get; set; }
}