namespace AzureWorkshop.CodeSamples.FunctionApps.Controllers;

public abstract class ControllerBase
{
    protected readonly IMediator _mediator;

    protected ControllerBase(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected async Task<IActionResult> ProcessRequestAsync(IRequest<IActionResult> request)
    {
        try
        {
            return await _mediator.Send(request);
        }
        catch (DomainException cse)
        {
            return cse.ToActionResult();
        }
        catch (ValidationException ve)
        {
            return new BadRequestObjectResult(ve.Message);
        }
    }
}