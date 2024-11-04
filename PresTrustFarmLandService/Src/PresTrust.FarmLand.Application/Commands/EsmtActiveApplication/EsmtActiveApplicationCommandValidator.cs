namespace PresTrust.FarmLand.Application.Commands;

public class EsmtActiveApplicationCommandValidator : AbstractValidator<EsmtActiveApplicationCommand>
{
    public EsmtActiveApplicationCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a Valid Application Id.");
    }
}
