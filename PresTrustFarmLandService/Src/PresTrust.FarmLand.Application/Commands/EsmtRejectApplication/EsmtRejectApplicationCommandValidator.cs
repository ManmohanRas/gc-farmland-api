namespace PresTrust.FarmLand.Application.Commands;
public class EsmtRejectApplicationCommandValidator:AbstractValidator<EsmtRejectApplicationCommand>
{
    public EsmtRejectApplicationCommandValidator()
    {
        RuleFor(command => command.ApplicationId)
            .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
