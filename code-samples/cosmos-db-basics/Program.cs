using System;
using System.Threading.Tasks;

namespace AzureFundamentalsWorkshop.CodeSamples.CosmosDB;

internal class Program
{
    private static readonly string endpointUrl = "<@replace-with-endpoint-uri>";
    private static readonly string accountKey = "<@replace-with-account-key>";

    private static async Task Main(string[] args)
    {
        var myCosmosService = new CosmosService();
        await myCosmosService.InitializeAsync(endpointUrl, accountKey);

        var newContact1 = new Contact
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "mithun",
            LastName = "shanbhag",
            Email = "mithun@cloudskew.com",
            City = "Bangalore"
        };

        var newContact2 = new Contact
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "john",
            LastName = "doe",
            Email = "john@doe.com",
            City = "Delhi"
        };

        try
        {
            await myCosmosService.AddContactAsync(newContact1);
            await myCosmosService.AddContactAsync(newContact2);

            foreach (var contact in await myCosmosService.ListContactsAsync())
            {
            }

            var contactToModify = await myCosmosService.GetContactAsync(newContact2.Id);

            contactToModify.FirstName = "Jane";
            await myCosmosService.UpdateContactAsync(contactToModify.Id, contactToModify);
        }
        finally
        {
            //await myCosmosService.DeleteContactAsync(newContact1.Id);
            //await myCosmosService.DeleteContactAsync(newContact1.Id);
        }
    }
}