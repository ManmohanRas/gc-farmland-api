namespace PresTrust.FarmLand.Application.Queries
{
    public class GetFarmSadcAppEligibilityQuery:IRequest<GetFarmSadcAppEligibilityQueryViewModel>
    {
        public int ApplicationId { get; set; }
    }
}
