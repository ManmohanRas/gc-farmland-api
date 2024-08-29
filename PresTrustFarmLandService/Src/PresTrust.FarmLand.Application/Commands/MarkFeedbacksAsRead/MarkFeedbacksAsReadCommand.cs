namespace PresTrust.FarmLand.Application.Commands;

public class MarkFeedbacksAsReadCommand : IRequest<bool>
{
    public List<int> FeedbackIds { get; set; }

}

