using System.Text.Json;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureWorkshop.CodeSamples.FunctionApps;

public static class CosmosDbInputFunctionPointQuery
{
    [FunctionName("CosmosDBInputFunctionPointQuery")]
    public static void UsePointQuery(
        [TimerTrigger("*/30 * * * * *")] TimerInfo myTimer,
        [CosmosDB("contactsdb", "contactscontainer",
            ConnectionStringSetting = "AzureWebJobsCosmosDB",
            PartitionKey = "12345", // replace later as appropriate
            Id = "12345")]
        // replace later as appropriate
        Contact contact,
        ILogger log)
    {
        if (contact != null) log.LogInformation($"document: {JsonSerializer.Serialize(contact)}");
    }
}