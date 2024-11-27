namespace PresTrust.FarmLand.Application.Commands;
public class SaveFarmEsmtSadcAppEligiblityTwoCommandValidator:AbstractValidator<SaveFarmEsmtSadcAppEligiblityTwoCommand>
{
    public SaveFarmEsmtSadcAppEligiblityTwoCommandValidator()
    {
        RuleFor(command => command.ApplicationId).GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
