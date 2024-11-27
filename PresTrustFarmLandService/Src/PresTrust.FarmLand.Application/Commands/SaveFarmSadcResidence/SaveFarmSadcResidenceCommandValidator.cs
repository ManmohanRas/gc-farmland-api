namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmSadcResidenceCommandValidator : AbstractValidator<SaveFarmSadcResidenceCommand>
{
    public SaveFarmSadcResidenceCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a valid Application Id.");
    }
}
