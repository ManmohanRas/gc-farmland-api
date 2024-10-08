
namespace PresTrust.FarmLand.Application.Queries;
public class GetEsmtAppAdminOfferCostsQueryHandler : BaseHandler, IRequestHandler<GetEsmtAppAdminOfferCostsQuery, GetEsmtAppAdminOfferCostsQueryViewModel>
{
    public IMapper mapper;
    public IApplicationRepository repoApplication;
    public IEsmtAppAdminOfferCostsRepository repoOfferCosts;
    public IEsmtAppSignatoryRepository repoSignatory;
    

    public GetEsmtAppAdminOfferCostsQueryHandler(
        IMapper mappper,
        IApplicationRepository repoApplication,
       IEsmtAppAdminOfferCostsRepository repoOfferCosts,
       IEsmtAppSignatoryRepository repoSignatory
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mappper;
        this.repoApplication = repoApplication;
        this.repoOfferCosts = repoOfferCosts;
        this.repoSignatory = repoSignatory;
    }

    public async Task<GetEsmtAppAdminOfferCostsQueryViewModel> Handle(GetEsmtAppAdminOfferCostsQuery request, CancellationToken cancellationToken)
    {

        var application = await GetIfApplicationExists(request.ApplicationId);
        var offerCosts = await repoOfferCosts.GetEsmtAppAdminOfferCostsAsync(request.ApplicationId);
        var esmtSignatory = await repoSignatory.GetSignatoryAsync(request.ApplicationId);
        esmtSignatory = esmtSignatory ?? new FarmEsmtAppSignatoryEntity();

        var result = mapper.Map<EsmtAppAdminOfferCostsEntity, GetEsmtAppAdminOfferCostsQueryViewModel>(offerCosts);
        result.AmountPerAcre = esmtSignatory.AmountPerAcre ?? 0;
        return result;      
    }
}
