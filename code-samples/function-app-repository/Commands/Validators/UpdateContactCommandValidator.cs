namespace AzureWorkshop.CodeSamples.FunctionApps.Commands.Validators;

public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
{
    public UpdateContactCommandValidator()
    {
        RuleFor(command => command.ContactId).NotEmpty();

        RuleFor(command => command.NewContactDto).NotNull();
        RuleFor(command => command.NewContactDto.Id).NotEmpty().Equal(command => command.ContactId);
        RuleFor(command => command.NewContactDto.Email).NotEmpty();
        RuleFor(command => command.NewContactDto.FirstName).NotEmpty();
        RuleFor(command => command.NewContactDto.LastName).NotEmpty();
    }
}