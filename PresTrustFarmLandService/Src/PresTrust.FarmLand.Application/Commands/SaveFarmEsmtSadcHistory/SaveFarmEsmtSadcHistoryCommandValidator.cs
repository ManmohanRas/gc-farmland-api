namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtSadcHistoryCommandValidator : AbstractValidator<SaveFarmEsmtSadcHistoryCommand>
{
    public SaveFarmEsmtSadcHistoryCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a valid Application Id.");
    }
}
