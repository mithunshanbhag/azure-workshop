namespace AzureWorkshop.CodeSamples.FunctionApps.Queries.Handlers;

public class ListImagesQueryHandler: IRequestPreProcessor<ListImagesQuery>, IRequestHandler<ListImagesQuery, IActionResult>
{
    public async Task Process(ListImagesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> Handle(ListImagesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}