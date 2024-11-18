namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtSadcHistoryQuery : IRequest<GetFarmEsmtSadcHistoryQueryViewModel>
{
    public int ApplicationId { get; set; }
}
