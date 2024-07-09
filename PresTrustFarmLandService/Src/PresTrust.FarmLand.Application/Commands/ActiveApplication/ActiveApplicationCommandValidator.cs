namespace PresTrust.FarmLand.Application.Commands;

public class ActiveApplicationCommandValidator : AbstractValidator<ActiveApplicationCommand>
{
    public ActiveApplicationCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
               .GreaterThan(0)
                .WithMessage("Not a Valid Application Id.");
    }
}
