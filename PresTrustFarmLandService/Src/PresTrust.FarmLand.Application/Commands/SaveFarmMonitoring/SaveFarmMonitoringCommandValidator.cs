namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmMonitoringCommandValidator : AbstractValidator<SaveFarmMonitoringCommand>
{
    public SaveFarmMonitoringCommandValidator()
    {
        RuleFor(command => command.FarmName)
                .NotEmpty().NotNull()
                .WithMessage("Farm Name should be Entered.");
    }
}
