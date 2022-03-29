using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace AzureWorkshop.CodeSamples.FunctionApps.Controllers;

public class ContactsController : ControllerBase
{
    public ContactsController(IMediator mediator) : base(mediator)
    {
    }

    [FunctionName("CreateContact")]
    public async Task<IActionResult> CreateContact(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "contacts")]
        ContactDto newContactDto)
    {
        var command = new CreateContactCommand
        {
            NewContactDto = newContactDto
        };

        return await ProcessRequestAsync(command);
    }

    [FunctionName("UpdateContact")]
    public async Task<IActionResult> UpdateContact(
        [HttpTrigger(AuthorizationLevel.Function, "put", Route = "contacts/{contactId:guid}")]
        ContactDto newContactDto,
        Guid contactId)
    {
        var command = new UpdateContactCommand
        {
            NewContactDto = newContactDto,
            ContactId = contactId
        };

        return await ProcessRequestAsync(command);
    }

    [FunctionName("DeleteContact")]
    public async Task<IActionResult> DeleteContact(
        [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "contacts/{contactId:guid}")]
        HttpRequest req,
        Guid contactId)
    {
        var command = new DeleteContactCommand
        {
            ContactId = contactId
        };

        return await ProcessRequestAsync(command);
    }

    [FunctionName("GetContactById")]
    public async Task<IActionResult> GetContactById(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "contacts/{contactId:guid}")]
        HttpRequest req,
        Guid contactId)
    {
        var query = new GetContactByIdQuery
        {
            ContactId = contactId
        };

        return await ProcessRequestAsync(query);
    }

    //[FunctionName("GetContactByEmail")]
    //public async Task<IActionResult> GetContactByEmail(
    //    [HttpTrigger(AuthorizationLevel.Function, "get", Route = "contacts/{email}")]
    //    HttpRequest req,
    //    string email)
    //{
    //    var query = new GetContactByEmailQuery
    //    {
    //        Email = email
    //    };

    //    return await ProcessRequestAsync(query);
    //}

    [FunctionName("ListContacts")]
    public async Task<IActionResult> ListContacts(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "contacts")]
        HttpRequest req)
    {
        var query = new ListContactsQuery();

        return await ProcessRequestAsync(query);
    }
}