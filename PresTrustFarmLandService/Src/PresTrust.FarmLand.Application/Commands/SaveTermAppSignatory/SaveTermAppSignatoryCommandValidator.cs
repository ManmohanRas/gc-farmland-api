namespace PresTrust.FarmLand.Application.Commands;
public class SaveTermAppSignatoryCommandValidator : AbstractValidator<SaveTermAppSignatoryCommand>
{
    public SaveTermAppSignatoryCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a valid Application Id.");

    }
}