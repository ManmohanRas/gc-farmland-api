

namespace PresTrust.FarmLand.Application.Commands;
public class SaveEsmtAppAdminOfferCostsCommandHandler : IRequestHandler<SaveEsmtAppAdminOfferCostsCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private IApplicationRepository repoApplication;
    private IEsmtAppAdminOfferCostsRepository repoOfferCosts;
    public SaveEsmtAppAdminOfferCostsCommandHandler(
        IMapper mapper,
        IPresTrustUserContext userContext,
        IApplicationRepository repoApplication,
        IEsmtAppAdminOfferCostsRepository repoOfferCosts
        )
    {
        this.mapper = mapper;
        this.userContext = userContext; 
        this.repoApplication = repoApplication;
        this.repoOfferCosts = repoOfferCosts;
    }
    public async Task<int> Handle(SaveEsmtAppAdminOfferCostsCommand request, CancellationToken cancellationToken)
    {
        var application = await repoApplication.GetApplicationAsync( request.ApplicationId );
        var reqOfferCosts = mapper.Map<SaveEsmtAppAdminOfferCostsCommand, EsmtAppAdminOfferCostsEntity>(request);
        reqOfferCosts.LastUpdatedBy = userContext.Email;
        reqOfferCosts = await repoOfferCosts.SaveEsmtAppAdminOfferCostsAsync(reqOfferCosts);       
        return reqOfferCosts.Id;
    } 
}
