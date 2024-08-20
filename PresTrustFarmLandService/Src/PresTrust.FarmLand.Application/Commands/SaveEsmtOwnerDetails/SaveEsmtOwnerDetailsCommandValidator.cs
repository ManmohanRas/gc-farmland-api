namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtOwnerDetailsCommandValidator : AbstractValidator<SaveEsmtOwnerDetailsCommand>
{
    public SaveEsmtOwnerDetailsCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a valid Application Id.");
    }
}
