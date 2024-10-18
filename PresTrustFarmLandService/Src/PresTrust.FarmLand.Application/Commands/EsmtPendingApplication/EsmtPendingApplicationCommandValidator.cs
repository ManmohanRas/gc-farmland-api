namespace PresTrust.FarmLand.Application.Commands;

public class EsmtPendingApplicationCommandValidator : AbstractValidator<EsmtPendingApplicationCommand>
{
    public EsmtPendingApplicationCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a Valid Application Id.");
    }
}
