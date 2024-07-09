namespace PresTrust.FarmLand.Application.Commands;

public class ApproveApplicationCommandValidator : AbstractValidator<ApproveApplicationCommand>
{
    public ApproveApplicationCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
               .GreaterThan(0)
                .WithMessage("Not a Valid Application Id.");
    }
}
