namespace PresTrust.FarmLand.Application.Commands;

public class DeleteTermAppDocumentCommandValidator : AbstractValidator<DeleteTermAppDocumentCommand>
{
    public DeleteTermAppDocumentCommandValidator()
    {
        RuleFor(command => command.ApplicationId)
             .GreaterThan(0).WithMessage("Not a valid Application Id");

        RuleFor(command => command.Id)
             .GreaterThan(0).WithMessage("Not a valid Document Id");
    }
}
