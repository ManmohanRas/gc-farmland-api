namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtAppAdminDetailsQuery : IRequest<GetFarmEsmtAppAdminDetailsQueryViewModel>
{
    public int ApplicationId { get; set; }
    public string UserId { get; set; }
}
