namespace PresTrust.FarmLand.Application.Commands;

public class ExpireApplicationCommandValidator : AbstractValidator<ExpireApplicationCommand>
{
    public ExpireApplicationCommandValidator()
    {
        RuleFor(command => command.ApplicationId)
          .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
