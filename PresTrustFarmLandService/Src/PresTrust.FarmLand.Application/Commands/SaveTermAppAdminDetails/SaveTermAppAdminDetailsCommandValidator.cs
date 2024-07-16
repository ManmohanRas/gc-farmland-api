namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppAdminDetailsCommandValidator : AbstractValidator<SaveTermAppAdminDetailsCommand>
{
    public SaveTermAppAdminDetailsCommandValidator()
    {
        RuleFor(query => query.ApplicationId).GreaterThan(0)

            .WithMessage("Not a valid Application Id.");
    }
}
