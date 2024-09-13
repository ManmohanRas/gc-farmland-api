namespace PresTrust.FarmLand.Application.Commands;

public class DeleteEsmtAppAttachmentCCommandValidator:AbstractValidator<DeleteEsmtAppAttachmentCCommand>
{

    public DeleteEsmtAppAttachmentCCommandValidator()
    {
        RuleFor(command => command.ApplicationId)
               .GreaterThan(0)
               .WithMessage("Not a valid Application Id");
    }
}
