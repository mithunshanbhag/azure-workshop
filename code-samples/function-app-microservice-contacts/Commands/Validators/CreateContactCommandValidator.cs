namespace AzureWorkshop.CodeSamples.FunctionApps.Commands.Validators;

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(command => command.NewContactDto).NotNull();
        RuleFor(command => command.NewContactDto.Email).NotEmpty();
        RuleFor(command => command.NewContactDto.FirstName).NotEmpty();
        RuleFor(command => command.NewContactDto.LastName).NotEmpty();
    }
}