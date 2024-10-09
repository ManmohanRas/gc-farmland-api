namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtOwnerDetailsCommandHandler : BaseHandler, IRequestHandler<SaveEsmtOwnerDetailsCommand, int>
{
    private IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private IEsmtOwnerDetailsRepository repoOwner;
    private readonly ITermBrokenRuleRepository repoBrokenRules;


    public SaveEsmtOwnerDetailsCommandHandler(
       IMapper mapper,
       IPresTrustUserContext userContext,
       IOptions<SystemParameterConfiguration> systemParamOptions,
       IApplicationRepository repoApplication,
       IEsmtOwnerDetailsRepository repoOwner,
        ITermBrokenRuleRepository repoBrokenRules
      ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoOwner = repoOwner;
        this.repoBrokenRules = repoBrokenRules;
    }

    public async Task<int> Handle(SaveEsmtOwnerDetailsCommand request, CancellationToken cancellationToken)
    {

        var application = await GetIfApplicationExists(request.ApplicationId);

        var reqEsmtOwner = mapper.Map<SaveEsmtOwnerDetailsCommand, EsmtOwnerDetailsEntity>(request);

        // Check Broken Rules
        var brokenRules = ReturnBrokenRulesIfAny(reqEsmtOwner);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {

            // Delete old Broken Rules, if any
            await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, EsmtAppSectionEnum.OWNER_DETAILS);
            
            // Save current Broken Rules, if any
            await repoBrokenRules.SaveBrokenRules(brokenRules);

            reqEsmtOwner = await repoOwner.SaveOwnerDetailsAsync(reqEsmtOwner);
            
            scope.Complete();
        }

        return reqEsmtOwner.Id;

    }

    private  List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(EsmtOwnerDetailsEntity reqEsmtOwner)
    {
        int sectionId = (int)EsmtAppSectionEnum.OWNER_DETAILS;
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();

        // add based on the empty check conditions
        if (string.IsNullOrEmpty(reqEsmtOwner.FarmName))
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = reqEsmtOwner.ApplicationId,
                SectionId = sectionId,
                Message = "Farm Name required field on Owner Details tab have not been filled.",
                IsApplicantFlow = true
            });

        return brokenRules;

    }
}
