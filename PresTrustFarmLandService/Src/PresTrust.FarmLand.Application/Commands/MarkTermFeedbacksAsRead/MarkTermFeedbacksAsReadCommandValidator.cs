namespace PresTrust.FarmLand.Application.Commands;

public class MarkTermFeedbacksAsReadCommandValidator : AbstractValidator<MarkTermFeedbacksAsReadCommand>
{
    public MarkTermFeedbacksAsReadCommandValidator()
    {
        RuleFor(command => command.FeedbackIds)
          .Must(o => o.Count > 0).WithMessage("Not a valid Feedback Id");
    }
}
