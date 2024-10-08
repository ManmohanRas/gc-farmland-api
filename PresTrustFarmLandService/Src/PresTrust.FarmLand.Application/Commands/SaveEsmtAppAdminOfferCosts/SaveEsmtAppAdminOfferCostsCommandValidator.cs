namespace PresTrust.FarmLand.Application.Commands;
public class SaveEsmtAppAdminOfferCostsCommandValidator:AbstractValidator<SaveEsmtAppAdminOfferCostsCommand>
{
    public SaveEsmtAppAdminOfferCostsCommandValidator()
    {
        RuleFor(query =>query.ApplicationId).GreaterThan(0).WithMessage("Not a Valid Application Id.");
    }
}
