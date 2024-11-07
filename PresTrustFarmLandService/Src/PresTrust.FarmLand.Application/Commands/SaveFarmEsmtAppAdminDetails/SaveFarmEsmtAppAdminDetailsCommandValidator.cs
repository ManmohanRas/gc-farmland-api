namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtAppAdminDetailsCommandValidator : AbstractValidator<SaveFarmEsmtAppAdminDetailsCommand>
{
    public SaveFarmEsmtAppAdminDetailsCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a valid Application Id.");
    }
}
