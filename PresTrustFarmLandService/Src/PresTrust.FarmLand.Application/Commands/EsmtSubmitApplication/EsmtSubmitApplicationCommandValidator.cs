namespace PresTrust.FarmLand.Application.Commands;

public class EsmtSubmitApplicationCommandValidator : AbstractValidator<RequestApplicationCommand>
{
    public EsmtSubmitApplicationCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a Valid Application Id.");
    }
}
