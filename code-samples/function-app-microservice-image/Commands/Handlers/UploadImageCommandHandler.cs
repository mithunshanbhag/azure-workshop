namespace AzureWorkshop.CodeSamples.FunctionApps.Commands.Handlers;

public class UploadImageCommandHandler : IRequestPreProcessor<UploadImageCommand>, IRequestHandler<UploadImageCommand, IActionResult>
{
    public async Task Process(UploadImageCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> Handle(UploadImageCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}