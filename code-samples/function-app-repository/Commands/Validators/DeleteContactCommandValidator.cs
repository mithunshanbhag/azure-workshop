namespace AzureWorkshop.CodeSamples.FunctionApps.Commands.Validators;

public class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommand>
{
    public DeleteContactCommandValidator()
    {
        RuleFor(command => command.ContactId).NotEmpty();
    }
}