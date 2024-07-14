

namespace PresTrust.FarmLand.Application.Queries;

public class GetTermAppAdminContactsQuery :IRequest<IEnumerable<GetTermAppAdminContactsQueryViewModel>>
{
    public int ApplicationId { get; set; }

}
