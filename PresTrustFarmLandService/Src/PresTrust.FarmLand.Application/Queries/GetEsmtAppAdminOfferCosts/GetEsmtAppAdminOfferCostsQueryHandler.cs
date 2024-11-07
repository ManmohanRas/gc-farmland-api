
namespace PresTrust.FarmLand.Application.Queries;
public class GetEsmtAppAdminOfferCostsQueryHandler : BaseHandler, IRequestHandler<GetEsmtAppAdminOfferCostsQuery, GetEsmtAppAdminOfferCostsQueryViewModel>
{
    public IMapper mapper;
    public IApplicationRepository repoApplication;
    public IEsmtAppAdminOfferCostsRepository repoOfferCosts;
    public IEsmtAppSignatoryRepository repoSignatory;
    private readonly IFarmEsmtAppAdminCostDetailsRepository repoCostDetails;
    

    public GetEsmtAppAdminOfferCostsQueryHandler(
        IMapper mappper,
        IApplicationRepository repoApplication,
       IEsmtAppAdminOfferCostsRepository repoOfferCosts,
       IEsmtAppSignatoryRepository repoSignatory,
       IFarmEsmtAppAdminCostDetailsRepository repoCostDetails
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mappper;
        this.repoApplication = repoApplication;
        this.repoOfferCosts = repoOfferCosts;
        this.repoSignatory = repoSignatory;
        this.repoCostDetails = repoCostDetails;
    }

    public async Task<GetEsmtAppAdminOfferCostsQueryViewModel> Handle(GetEsmtAppAdminOfferCostsQuery request, CancellationToken cancellationToken)
    {

        var application = await GetIfApplicationExists(request.ApplicationId);
        var offerCosts = await repoOfferCosts.GetEsmtAppAdminOfferCostsAsync(request.ApplicationId);
        var esmtSignatory = await repoSignatory.GetSignatoryAsync(request.ApplicationId);
        esmtSignatory = esmtSignatory ?? new FarmEsmtAppSignatoryEntity();
        var costDetails = await repoCostDetails.GetCostDetailsAsync(request.ApplicationId);
        costDetails = costDetails ?? new FarmEsmtAppAdminCostDetailsEntity();
        var result = mapper.Map<EsmtAppAdminOfferCostsEntity, GetEsmtAppAdminOfferCostsQueryViewModel>(offerCosts);
        result.AmountPerAcre = esmtSignatory.AmountPerAcre ?? 0;
        result.TotalCostPerAcre = costDetails.TotalCostPerAcre ?? 0;
        result.TotalCost = costDetails.TotalCost ?? 0;
        result.MCCostSharePct  = costDetails.MCCostShareTotal ?? 0;
        result.McCountyCostShareTotal = costDetails.MCCostSharePct ?? 0;
        result.SADCCostSharePct  = costDetails.SADCCostShareTotal ?? 0;
        result.SADCCostShareTotal = costDetails.SADCCostShareofOfferPct ?? 0;
        result.OtherCostShareTotal = costDetails.OtherCostShare ?? 0;


        return result;      
    }
}
