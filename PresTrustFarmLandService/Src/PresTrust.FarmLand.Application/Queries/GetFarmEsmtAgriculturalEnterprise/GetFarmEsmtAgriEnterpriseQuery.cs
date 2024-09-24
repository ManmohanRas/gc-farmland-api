namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtAgriEnterpriseQuery : IRequest<GetFarmEsmtAgriEnterpriseQueryViewModel>
{
    public int ApplicationId { get; set; }
}
