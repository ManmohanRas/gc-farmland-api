namespace PresTrust.FarmLand.Application.Commands;

/// <summary>
/// create rules for attributes
/// </summary>
public class CreateEsmtApplicationCommandValidator: AbstractValidator<CreateEsmtApplicationCommand>
{
    public CreateEsmtApplicationCommandValidator()
    {
        RuleFor(command => command.AgencyId)
           .GreaterThan(0).WithMessage("Not a valid agency");

        RuleFor(command => command.FarmListId)
           .GreaterThan(0).WithMessage("Not a valid farm");
    }
}
