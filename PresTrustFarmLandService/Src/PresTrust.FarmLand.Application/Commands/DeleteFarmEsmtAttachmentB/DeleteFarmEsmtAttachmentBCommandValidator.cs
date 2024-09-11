namespace PresTrust.FarmLand.Application.Commands;

public class DeleteFarmEsmtAttachmentBCommandValidator : AbstractValidator<DeleteFarmEsmtAttachmentBCommand>
{
    public DeleteFarmEsmtAttachmentBCommandValidator()
    {
        RuleFor(command => command.ApplicationId)
           .GreaterThan(0)
           .WithMessage("Not a valid Application Id");

    }
}
