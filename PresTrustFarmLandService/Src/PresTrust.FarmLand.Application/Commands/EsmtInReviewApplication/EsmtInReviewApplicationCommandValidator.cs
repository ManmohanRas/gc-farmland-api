namespace PresTrust.FarmLand.Application.Commands;

public class EsmtInReviewApplicationCommandValidator : AbstractValidator<EsmtInReviewApplicationCommand>
{
    public EsmtInReviewApplicationCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a Valid Application Id.");
    }
}
