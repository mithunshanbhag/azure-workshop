namespace AzureWorkshop.CodeSamples.FunctionApps.Queries.Validators;

public class GetContactByEmailQueryValidator : AbstractValidator<GetContactByEmailQuery>
{
    public GetContactByEmailQueryValidator()
    {
        RuleFor(query => query.Email).NotEmpty();
    }
}