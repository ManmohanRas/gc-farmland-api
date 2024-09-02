namespace PresTrust.FarmLand.Application.Commands;

public class DeleteAppAdminContactsCommandValidator:AbstractValidator<DeleteTermAppAdminContactsCommand>
{
    public DeleteAppAdminContactsCommandValidator()
    {

        RuleFor(query => query.ApplicationId)
           .GreaterThan(0)
           .WithMessage("Not a valid ApplicationId");
    }
}
