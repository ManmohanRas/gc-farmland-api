namespace PresTrust.FarmLand.Application.Queries;
public class GetFarmEsmtSadcFarmInfoQuery:IRequest<GetFarmEsmtSadcFarmInfoQueryViewModel>
{
    public int ApplicationId { get; set; }
    public int FarmListID { get; set; }
}
