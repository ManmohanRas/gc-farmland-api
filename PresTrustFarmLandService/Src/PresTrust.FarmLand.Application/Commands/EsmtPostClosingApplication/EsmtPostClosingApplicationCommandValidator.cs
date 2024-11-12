namespace PresTrust.FarmLand.Application.Commands;

public class EsmtPostClosingApplicationCommandValidator : AbstractValidator<EsmtPostClosingApplicationCommand>
{
    public EsmtPostClosingApplicationCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a Valid Application Id.");
    }
}
