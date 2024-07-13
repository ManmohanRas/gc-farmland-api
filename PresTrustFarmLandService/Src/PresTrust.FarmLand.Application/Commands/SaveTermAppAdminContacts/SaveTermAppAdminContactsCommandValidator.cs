
namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppAdminContactsCommandValidator:AbstractValidator<SaveTermAppAdminContactsCommand>
{
    public SaveTermAppAdminContactsCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
            .GreaterThan(0)
            .WithMessage("ApplicationId must be greater than 0");
    }
}
