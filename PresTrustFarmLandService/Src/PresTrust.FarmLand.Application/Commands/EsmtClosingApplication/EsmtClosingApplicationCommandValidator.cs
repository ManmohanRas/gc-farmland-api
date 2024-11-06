namespace PresTrust.FarmLand.Application.Commands;

public class EsmtClosingApplicationCommandValidator : AbstractValidator<EsmtClosingApplicationCommand>
{
    public EsmtClosingApplicationCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a Valid Application Id.");
    }
}
