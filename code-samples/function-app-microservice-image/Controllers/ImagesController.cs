using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace AzureWorkshop.CodeSamples.FunctionApps.Controllers;

public class ImagesController : ControllerBase
{
    public ImagesController(IMediator mediator) : base(mediator)
    {
    }

    //[FunctionName("UploadImage")]
    //public async Task<IActionResult> UploadImage(
    //    [HttpTrigger(AuthorizationLevel.Function, "post", Route = "contacts/{contactId:guid}/images")]
    //    ContactDto newContactDto)
    //{
    //    var command = new UploadImageCommand
    //    {
    //    };

    //    return await ProcessRequestAsync(command);
    //}

    [FunctionName("DeleteImage")]
    public async Task<IActionResult> DeleteImage(
        [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "contacts/{contactId:guid}/images/{imageId:guid}")]
        HttpRequest req,
        Guid contactId,
        Guid imageId)
    {
        var command = new DeleteImageCommand
        {
        };

        return await ProcessRequestAsync(command);
    }

    [FunctionName("GetImageById")]
    public async Task<IActionResult> GetImageById(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "contacts/{contactId:guid}/images/{imageId:guid}")]
        HttpRequest req,
        Guid contactId,
        Guid imageId)
    {
        var query = new GetImageByIdQuery
        {
        };

        return await ProcessRequestAsync(query);
    }

    [FunctionName("ListImages")]
    public async Task<IActionResult> ListImages(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "contacts/{contactId:guid}/images")]
        HttpRequest req,
        Guid contactId)
    {
        var query = new ListImagesQuery();

        return await ProcessRequestAsync(query);
    }
}