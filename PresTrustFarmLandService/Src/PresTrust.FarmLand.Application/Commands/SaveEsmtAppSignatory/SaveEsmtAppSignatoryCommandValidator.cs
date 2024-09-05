namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppSignatoryCommandValidator : AbstractValidator<SaveEsmtAppSignatoryCommand>
{
    public SaveEsmtAppSignatoryCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a valid Application Id.");

    }
}
