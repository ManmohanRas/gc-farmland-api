namespace PresTrust.FarmLand.Application.Commands
{
    public class SaveFarmSadcAppEligibilityCommandValidator : AbstractValidator<SaveFarmSadcAppEligibilityCommand>
    {
        public SaveFarmSadcAppEligibilityCommandValidator()
        {
            RuleFor(query => query.ApplicationId).GreaterThan(0).WithMessage("Not a Valid Application Id.");
        }
    }
}

