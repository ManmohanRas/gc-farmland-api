namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtSadcHistoryCommandValidator : AbstractValidator<SaveFarmEsmtAppAdminDetailsCommand>
{
    public SaveFarmEsmtSadcHistoryCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a valid Application Id.");
    }
}
