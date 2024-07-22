namespace PresTrust.FarmLand.Application.Commands;

/// <summary>
/// create rules for attributes
/// </summary>
public class CreateApplicationCommandValidator: AbstractValidator<CreateApplicationCommand>
{
    public CreateApplicationCommandValidator()
    {
        RuleFor(command => command.AgencyId)
           .GreaterThan(0).WithMessage("Not a valid agency");

        RuleFor(command => command.FarmListId)
           .GreaterThan(0).WithMessage("Not a valid farm");
    }
}
