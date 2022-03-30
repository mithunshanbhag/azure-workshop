namespace AzureWorkshop.CodeSamples.FunctionApps.Commands.Handlers;

public class DeleteImageCommandHandler : IRequestPreProcessor<DeleteImageCommand>, IRequestHandler<DeleteImageCommand, IActionResult>
{
    public Task Process(DeleteImageCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Handle(DeleteImageCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}