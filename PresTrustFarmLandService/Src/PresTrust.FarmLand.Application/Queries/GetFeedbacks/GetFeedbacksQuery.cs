namespace PresTrust.FarmLand.Application.Queries;

public class GetFeedbacksQuery: IRequest<IEnumerable<GetFeedbacksQueryViewModel>>
{
    public int ApplicationId { get; set; }
}
