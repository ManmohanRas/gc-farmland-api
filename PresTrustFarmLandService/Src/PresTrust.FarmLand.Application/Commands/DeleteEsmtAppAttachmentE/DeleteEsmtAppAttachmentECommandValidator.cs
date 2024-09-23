namespace PresTrust.FarmLand.Application.Commands;

public class DeleteEsmtAppAttachmentECommandValidator:AbstractValidator<DeleteEsmtAppAttachmentECommand>
{
    public DeleteEsmtAppAttachmentECommandValidator()
    {
        RuleFor(command => command.ApplicationId)
         .GreaterThan(0)
         .WithMessage("Not a valid Application Id");
    }
}
