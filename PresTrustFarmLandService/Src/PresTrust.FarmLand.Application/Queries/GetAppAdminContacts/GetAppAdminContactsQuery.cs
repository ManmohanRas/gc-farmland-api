namespace PresTrust.FarmLand.Application.Queries;

public class GetAppAdminContactsQuery :IRequest<IEnumerable<GetAppAdminContactsQueryViewModel>>
{
    public int ApplicationId { get; set; }

}
