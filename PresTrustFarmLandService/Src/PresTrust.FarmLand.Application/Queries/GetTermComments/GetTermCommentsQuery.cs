namespace PresTrust.FarmLand.Application.Queries;

public class GetTermCommentsQuery : IRequest<IEnumerable<GetTermCommentsQueryViewModel>>
{
    public int ApplicationId {  get; set; }
}
