namespace PresTrust.FarmLand.Application.Commands;

public class DeleteTermCommentCommandValidator : AbstractValidator<DeleteTermCommentCommand>
{
    public DeleteTermCommentCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
           .GreaterThan(0)
           .WithMessage("Not a valid ApplicationId");

        RuleFor(query => query.Id)
            .GreaterThan(0)
            .WithMessage("Not a valid CommentId");
    }
}
