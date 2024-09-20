namespace PresTrust.FarmLand.Application.Commands;

public class DeleteFarmEsmtAttachmentACommandValidator : AbstractValidator<DeleteFarmEsmtAttachmentACommand>
{
    public DeleteFarmEsmtAttachmentACommandValidator()
    {
        RuleFor(command => command.ApplicationId)
           .GreaterThan(0)
           .WithMessage("Not a valid Application Id");

    }
}
