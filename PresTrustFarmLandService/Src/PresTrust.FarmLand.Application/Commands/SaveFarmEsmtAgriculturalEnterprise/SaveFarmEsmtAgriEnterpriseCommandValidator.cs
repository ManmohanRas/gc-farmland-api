namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtAgriEnterpriseCommandValidator : AbstractValidator<SaveFarmEsmtAgriEnterpriseCommand>
{
    public SaveFarmEsmtAgriEnterpriseCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a valid Application Id.");

    }
}
