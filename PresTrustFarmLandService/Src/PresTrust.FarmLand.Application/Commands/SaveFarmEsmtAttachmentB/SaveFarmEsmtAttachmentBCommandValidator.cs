namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtAttachmentBCommandValidator : AbstractValidator<SaveFarmEsmtAttachmentBCommand>
{
    public SaveFarmEsmtAttachmentBCommandValidator()
    {
        RuleFor(command => command.ApplicationId)
            .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
