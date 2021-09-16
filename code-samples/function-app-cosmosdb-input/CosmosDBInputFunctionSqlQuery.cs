using System.Collections.Generic;
using System.Text.Json;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApp
{
    public static class CosmosDBInputFunctionSqlQuery
    {
        [FunctionName("CosmosDBInputFunctionSqlQuery")]
        public static void UseSqlQuery(
            [TimerTrigger("*/30 * * * * *")] TimerInfo myTimer,
            [CosmosDB("contactsdb", "contactscontainer",
                ConnectionStringSetting = "AzureWebJobsCosmosDB",
                SqlQuery = "select * from c")] // replace later as appropriate
                IEnumerable<Contact> contacts,
            ILogger log)
        {
            foreach (var contact in contacts)
            {
                log.LogInformation($"document: {JsonSerializer.Serialize<Contact>(contact)}");
            }
        }
    }
}
