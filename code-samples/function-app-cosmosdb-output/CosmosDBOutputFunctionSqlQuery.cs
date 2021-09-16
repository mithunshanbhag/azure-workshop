using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApp
{
    public static class CosmosDBOutputFunctionSqlQuery
    {
        [FunctionName("CosmosDBOutputFunctionSqlQuery")]
        public static void UseSqlQuery(
            [TimerTrigger("*/30 * * * * *")] TimerInfo myTimer,
            [CosmosDB("contactsdb", "contactscontainer", // replace later as appropriate
                ConnectionStringSetting = "AzureWebJobsCosmosDB",
                SqlQuery = "select * from c")] // replace later as appropriate
                IEnumerable<Contact> contacts,
            ILogger log)
        {
            foreach (var contact in contacts)
            {
                contact.FirstName = "Leonardo";
            }
        }
    }
}
