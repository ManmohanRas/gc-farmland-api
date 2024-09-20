using PresTrust.FarmLand.Application.Commands.SaveFarmEsmtAttachmentA;

namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtAttachmentACommandValidator : AbstractValidator<SaveFarmEsmtAttachmentACommand>
{
    public SaveFarmEsmtAttachmentACommandValidator()
    {
        RuleFor(command => command.ApplicationId)
            .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
