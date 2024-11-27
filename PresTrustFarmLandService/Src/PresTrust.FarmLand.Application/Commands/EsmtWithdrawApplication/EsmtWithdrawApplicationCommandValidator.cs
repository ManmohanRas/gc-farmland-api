namespace PresTrust.FarmLand.Application.Commands;

public class EsmtWithdrawApplicationCommandValidator : AbstractValidator<EsmtWithdrawApplicationCommand>
{
    public EsmtWithdrawApplicationCommandValidator()
    {
        RuleFor(command => command.ApplicationId)
             .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
