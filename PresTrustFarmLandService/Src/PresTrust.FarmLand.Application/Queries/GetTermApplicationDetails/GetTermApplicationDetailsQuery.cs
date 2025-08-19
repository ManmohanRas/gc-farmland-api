namespace PresTrust.FarmLand.Application.Queries;

public class GetTermApplicationDetailsQuery: IRequest<GetTermApplicationDetailsQueryViewModel>
{
    public int ApplicationId { get; set; }
    public string UserId { get; set; }
}
