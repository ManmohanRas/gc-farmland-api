namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmListCommandValidator: AbstractValidator<SaveFarmListCommand>
{
    public SaveFarmListCommandValidator()
    {
        RuleFor(command => command.FarmName)
                .NotEmpty().NotNull()
                .WithMessage("Farm Name can't be empty.");
    }
}
