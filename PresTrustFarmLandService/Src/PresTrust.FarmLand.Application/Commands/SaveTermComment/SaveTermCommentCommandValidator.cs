namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermCommentCommandValidator : AbstractValidator<SaveTermCommentCommand>
{
    public SaveTermCommentCommandValidator()
    {
        RuleFor(query => query.Comment)
              .NotNull().NotEmpty()
              .WithMessage("Comments cannot be empty.");

        RuleFor(query => query.ApplicationId)
            .GreaterThan(0)
            .WithMessage("ApplicationId must be greater than 0");
    }
}
