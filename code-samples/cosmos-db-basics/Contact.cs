using Newtonsoft.Json;

namespace AzureFundamentalsWorkshop.CodeSamples.CosmosDB
{
    public class Contact
    {
        [JsonProperty(PropertyName = "id")]
        public string Id {get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string City { get; set; }
    }
}