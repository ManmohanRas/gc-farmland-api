namespace PresTrust.FarmLand.Application.Commands;

public class EnableSadcCommandValidator : AbstractValidator<EnableSadcCommand>
{
    public EnableSadcCommandValidator()
    {
        RuleFor(command => command.ApplicationId)
             .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
