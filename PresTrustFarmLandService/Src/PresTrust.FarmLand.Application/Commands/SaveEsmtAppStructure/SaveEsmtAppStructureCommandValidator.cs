

namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppStructureCommandValidator:AbstractValidator<SaveEsmtAppStructureCommand>
{

    public SaveEsmtAppStructureCommandValidator()
    {
        RuleFor(query => query.ApplicationId).GreaterThan(0)

           .WithMessage("Not a valid Application Id.");
    }
}
