

namespace PresTrust.FarmLand.Application.Commands;

public class DeleteTermAppAdminContactsCommandValidator:AbstractValidator<DeleteTermAppAdminContactsCommand>
{
    public DeleteTermAppAdminContactsCommandValidator()
    {

        RuleFor(query => query.ApplicationId)
           .GreaterThan(0)
           .WithMessage("Not a valid ApplicationId");
    }
}
