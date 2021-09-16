using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApp
{
    public static class CosmosDBMultipleOutputFunction
    {
        [FunctionName("CosmosDBMultipleOutputFunction")]
        public async static Task UseMultipleOutputs(
            [TimerTrigger("*/30 * * * * *")] TimerInfo myTimer,
            [CosmosDB("contactsdb", "contactscontainer", // replace later as appropriate
                ConnectionStringSetting = "AzureWebJobsCosmosDB")]
                IAsyncCollector<Contact> contactsToWrite,
            ILogger log)
        {
            var newContacts = new List<Contact>
            {
                new Contact { FirstName = "Michael", LastName = "Schumacher", Id = Guid.NewGuid().ToString() },
                new Contact { FirstName = "Sebastian", LastName = "Vettel", Id = Guid.NewGuid().ToString() },
                new Contact { FirstName = "Lewis", LastName = "Hamilton", Id = Guid.NewGuid().ToString() },
            };

            foreach (var newContact in newContacts)
            {
                await contactsToWrite.AddAsync(newContact);
            }
        }
    }
}
