namespace PresTrust.FarmLand.Application.Commands;

public class SaveOwnerDetailsCommandValidator : AbstractValidator<SaveOwnerDetailsCommand>
{
    public SaveOwnerDetailsCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a valid Application Id.");
    }
}