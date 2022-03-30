namespace AzureWorkshop.CodeSamples.FunctionApps.Queries.Handlers;

public class GetImageByIdQueryHandler: IRequestPreProcessor<GetImageByIdQuery>, IRequestHandler<GetImageByIdQuery, IActionResult>
{
    public async Task Process(GetImageByIdQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> Handle(GetImageByIdQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}