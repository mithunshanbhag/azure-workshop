using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureWorkshop.CodeSamples.FunctionApps;

public static class CosmosDBMultipleOutputFunction
{
    [FunctionName("CosmosDBMultipleOutputFunction")]
    public static async Task Run(
        [TimerTrigger("*/30 * * * * *")] TimerInfo myTimer,
        [CosmosDB("contactsdb", "contactscontainer", Connection = "AzureWebJobsCosmosDB")]
        IAsyncCollector<Contact> contactsToWrite,
        ILogger log)
    {
        var newContacts = new List<Contact>
        {
            new() {FirstName = "Michael", LastName = "Schumacher", Id = Guid.NewGuid().ToString()},
            new() {FirstName = "Sebastian", LastName = "Vettel", Id = Guid.NewGuid().ToString()},
            new() {FirstName = "Lewis", LastName = "Hamilton", Id = Guid.NewGuid().ToString()}
        };

        foreach (var newContact in newContacts) await contactsToWrite.AddAsync(newContact);
    }
}