namespace PresTrust.FarmLand.Application.Commands;

public class EsmtPreservedApplicationCommandValidator : AbstractValidator<EsmtPreservedApplicationCommand>
{
    public EsmtPreservedApplicationCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
              .GreaterThan(0)
              .WithMessage("Not a Valid Application Id.");
    }
}
