namespace PresTrust.FarmLand.Application.Commands;

public class DeleteAppDocumentCommandValidator : AbstractValidator<DeleteAppDocumentCommand>
{
    public DeleteAppDocumentCommandValidator()
    {
        RuleFor(command => command.ApplicationId)
             .GreaterThan(0).WithMessage("Not a valid Application Id");

        RuleFor(command => command.Id)
             .GreaterThan(0).WithMessage("Not a valid Document Id");
    }
}
