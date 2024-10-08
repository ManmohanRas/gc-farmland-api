namespace PresTrust.FarmLand.Application.Queries;
public class GetEsmtAppAdminOfferCostsQuery:IRequest<GetEsmtAppAdminOfferCostsQueryViewModel>
{
   public int ApplicationId { get; set; }
}
