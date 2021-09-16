using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApp
{
    public static class CosmosDBInputFunctionBindingExpression
    {
        [FunctionName("CosmosDBInputFunctionBindingExpression")]
        public static void UseBindingExpression(
            [BlobTrigger("mycontainer1/{blobName}")] string blob, // replace later as appropriate
            [CosmosDB("contactsdb", "contactscontainer",
                ConnectionStringSetting = "AzureWebJobsCosmosDB",
                SqlQuery = "select * from c where c.lastName = {blobName}")] // replace later as appropriate
                IEnumerable<Contact> contacts,
            string blobName,
            ILogger log)
        {
            log.LogInformation($"blob name: {blobName}");
            log.LogInformation($"found {contacts.Count()} documents");

            foreach (var contact in contacts)
            {
                log.LogInformation($"document: {JsonSerializer.Serialize<Contact>(contact)}");
            }
        }
    }
}
