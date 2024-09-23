namespace PresTrust.FarmLand.Application.Commands;
public class SaveEsmtAppAttachmentECommandValidator:AbstractValidator<SaveEsmtAppAttachmentECommand>
{
    public SaveEsmtAppAttachmentECommandValidator()
    {
        RuleFor(query => query.ApplicationId).GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
