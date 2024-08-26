
namespace PresTrust.FarmLand.Application.Commands;

public class SaveSiteCharacteristicsCommandHandler : BaseHandler, IRequestHandler<SaveSiteCharacteristicsCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private ISiteCharacteristicsRepository repoSiteCharacteristics;
    private ITermBrokenRuleRepository repoBrokenRules;

    public SaveSiteCharacteristicsCommandHandler(
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        ISiteCharacteristicsRepository repoSiteCharacteristics,
        ITermBrokenRuleRepository repoBrokenRules

        ):base(repoApplication:repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;      
        this.repoSiteCharacteristics = repoSiteCharacteristics;
        this.repoBrokenRules = repoBrokenRules;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ///
    public async Task<int> Handle(SaveSiteCharacteristicsCommand request, CancellationToken cancellationToken)
    {

        var application = await GetIfApplicationExists(request.ApplicationId);

        var reqSiteCharacteristics = mapper.Map<SaveSiteCharacteristicsCommand, SiteCharacteristicsEntity>(request);

        var brokenRules = ReturnBrokenRulesIfAny(application, reqSiteCharacteristics);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, ApplicationSectionEnum.TERM_SITE_CHARACTERISTICS);
            await repoBrokenRules.SaveBrokenRules(brokenRules);
            reqSiteCharacteristics = await repoSiteCharacteristics.SaveSiteCharacteristicsAsync(reqSiteCharacteristics);
            reqSiteCharacteristics.LastUpdatedBy = userContext.Email;
            scope.Complete();

        }
        return reqSiteCharacteristics.Id;

    }

    private List<TermBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmApplicationEntity application, SiteCharacteristicsEntity reqSiteCharacteristics)
    {
        int sectionId = (int)ApplicationSectionEnum.TERM_SITE_CHARACTERISTICS;
        List<TermBrokenRuleEntity> brokenRules = new List<TermBrokenRuleEntity>();

            if(string.IsNullOrEmpty( reqSiteCharacteristics.Area))
            {
                brokenRules.Add(new TermBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Area  required field on Site Characteristics Tab have not been filled.",
                    IsApplicantFlow = false

                });
            }
            if(string.IsNullOrEmpty(reqSiteCharacteristics.EasementRightOfway))
            {

                brokenRules.Add(new TermBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Easement Right Of Way  required field on Site Characteristics Tab have not been filled.",
                    IsApplicantFlow = false
                });

            }
        
        return brokenRules;
    }


}
