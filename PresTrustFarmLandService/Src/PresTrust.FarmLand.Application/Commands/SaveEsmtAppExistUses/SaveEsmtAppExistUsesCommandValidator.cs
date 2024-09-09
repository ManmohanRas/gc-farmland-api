namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppExistUsesCommandValidator:AbstractValidator<SaveEsmtAppExistUsesCommand>
{
    public SaveEsmtAppExistUsesCommandValidator()
    {
        RuleFor(query => query.ApplicationId).GreaterThan(0)

           .WithMessage("Not a valid Application Id.");
    }
}
