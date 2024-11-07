namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtAppAdminDetailsQuery : IRequest<GetFarmEsmtAppAdminDetailsQueryViewModel>
{
    public int ApplicationId { get; set; }
}
