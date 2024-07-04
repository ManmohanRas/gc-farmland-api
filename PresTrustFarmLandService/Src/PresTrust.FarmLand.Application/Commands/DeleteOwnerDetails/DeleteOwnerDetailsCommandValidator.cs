namespace PresTrust.FarmLand.Application.Commands;

public class DeleteOwnerDetailsCommandValidator : AbstractValidator<DeleteOwnerDetailsCommand>
{
    public DeleteOwnerDetailsCommandValidator()
    {
        RuleFor(query => query.ApplicationId)
         .GreaterThan(0)
         .WithMessage("Not a valid ApplicationId");

        RuleFor(query => query.Id)
            .GreaterThan(0)
            .WithMessage("Not a valid CommentId");
    }
}
