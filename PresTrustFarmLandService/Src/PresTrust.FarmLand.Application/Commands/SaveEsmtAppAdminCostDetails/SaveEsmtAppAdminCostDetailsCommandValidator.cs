namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppAdminCostDetailsCommandValidator : AbstractValidator<SaveEsmtAppAdminCostDetailsCommand>
{
    public SaveEsmtAppAdminCostDetailsCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a valid Application Id.");

    }
}
