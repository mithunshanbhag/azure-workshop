using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps;

public static class CosmosDBOutputFunction
{
    [FunctionName("CosmosDBOutputFunctionSqlQuery")]
    public static void Run(
        [TimerTrigger("*/30 * * * * *")] TimerInfo myTimer,
        [CosmosDB("contactsdb", "contactscontainer", ConnectionStringSetting = "AzureWebJobsCosmosDB")]
        out dynamic contact,
        ILogger log)
    {
        contact = new Contact
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "Lewis",
            LastName = "Hamilton"
        };
    }
}