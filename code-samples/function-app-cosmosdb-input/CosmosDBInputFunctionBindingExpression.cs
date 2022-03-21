using System.Text.Json;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureWorkshop.CodeSamples.FunctionApps;

public static class CosmosDbInputFunctionBindingExpression
{
    [FunctionName("CosmosDBInputFunctionBindingExpression")]
    public static void UseBindingExpression(
        [BlobTrigger("mycontainer1/{blobName}")]
        string blob, // replace later as appropriate
        [CosmosDB("contactsdb", "contactscontainer",
            ConnectionStringSetting = "AzureWebJobsCosmosDB",
            SqlQuery = "select * from c where c.LastName = {blobName}")]
        // replace later as appropriate
        IEnumerable<Contact> contacts,
        string blobName,
        ILogger log)
    {
        log.LogInformation($"blob name: {blobName}");
        log.LogInformation($"found {contacts.Count()} documents");

        foreach (var contact in contacts) log.LogInformation($"document: {JsonSerializer.Serialize(contact)}");
    }
}