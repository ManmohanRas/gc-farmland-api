namespace PresTrust.FarmLand.Application.Commands;

/// <summary>
/// create rules for attributes
/// </summary>
public class CreateTermApplicationCommandValidator: AbstractValidator<CreateTermApplicationCommand>
{
    public CreateTermApplicationCommandValidator()
    {
        RuleFor(command => command.AgencyId)
           .GreaterThan(0).WithMessage("Not a valid agency");

        RuleFor(command => command.FarmListId)
           .GreaterThan(0).WithMessage("Not a valid farm");
    }
}
