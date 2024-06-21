namespace PresTrust.FarmLand.Application.Commands;

public class MarkTermFeedbacksAsReadCommand : IRequest<bool>
{
    public List<int> FeedbackIds { get; set; }

}

