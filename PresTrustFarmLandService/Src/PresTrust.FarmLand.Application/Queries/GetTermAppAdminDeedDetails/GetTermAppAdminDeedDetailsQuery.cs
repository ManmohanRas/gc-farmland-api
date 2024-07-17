namespace PresTrust.FarmLand.Application.Queries;

public class GetTermAppAdminDeedDetailsQuery : IRequest<GetTermAppAdminDeedDetailsQueryViewModel>
{
    public int ApplicationId { get; set; }

}
