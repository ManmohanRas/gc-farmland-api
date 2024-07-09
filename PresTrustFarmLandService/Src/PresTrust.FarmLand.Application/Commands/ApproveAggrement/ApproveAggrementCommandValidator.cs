namespace PresTrust.FarmLand.Application.Commands;

public class ApproveAggrementCommandValidator : AbstractValidator<ApproveApplicationCommand>
{
    public ApproveAggrementCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
               .GreaterThan(0)
                .WithMessage("Not a Valid Application Id.");
    }
}
