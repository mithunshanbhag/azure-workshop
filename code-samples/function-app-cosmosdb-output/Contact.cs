using System.Text.Json.Serialization;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps;

public class Contact
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    [JsonPropertyName("id")] public string Id { get; set; }
}