namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppAttachmentCCommandValidator:AbstractValidator<SaveEsmtAppAttachmentCCommand>
{
    public SaveEsmtAppAttachmentCCommandValidator()
    {
        RuleFor(query => query.ApplicationId).GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
