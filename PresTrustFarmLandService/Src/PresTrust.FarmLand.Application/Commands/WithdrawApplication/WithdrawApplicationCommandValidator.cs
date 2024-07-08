namespace PresTrust.FarmLand.Application.Commands;

public class WithdrawApplicationCommandValidator : AbstractValidator<WithdrawApplicationCommand>
{
    public WithdrawApplicationCommandValidator()
    {
        RuleFor(command => command.ApplicationId)
             .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
