namespace PresTrust.FarmLand.Application.Queries;
public class GetEsmtAppAdminCostDetailsQuery : IRequest<GetEsmtAppAdminCostDetailsQueryViewModel>
{
    public int ApplicationId { get; set; }
}
