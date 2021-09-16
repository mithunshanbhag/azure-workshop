using System.Collections.Generic;
using System.Text.Json;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApp
{
    public static class CosmosDBTriggerFunction
    {
        [FunctionName("CosmosDBTriggerFunction")]
        public static void Run([CosmosDBTrigger("contactsdb", "contactscontainer",
            ConnectionStringSetting = "AzureWebJobsCosmosDB",
            CreateLeaseCollectionIfNotExists = true)]
            IReadOnlyList<Document> documents,
            ILogger log)
        {
            log.LogInformation($"Documents created/modified = {documents.Count}");

            foreach(var document in documents)
            {
                var contact = JsonSerializer.Deserialize<Contact>(document.ToString());
                log.LogInformation($"document: {JsonSerializer.Serialize(contact)}");
            }
        }
    }
}
