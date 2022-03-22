namespace AzureWorkshop.CodeSamples.FunctionApps.Queries.Validators;

public class GetContactByIdQueryValidator : AbstractValidator<GetContactByIdQuery>
{
    public GetContactByIdQueryValidator()
    {
        RuleFor(query => query.ContactId).NotEmpty();
    }
}