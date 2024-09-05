namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppSignatoryCommandHandler : BaseHandler, IRequestHandler<SaveEsmtAppSignatoryCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private IEsmtAppSignatoryRepository repoSignatory;
    //private readonly ITermBrokenRuleRepository repoBrokenRules;


    public SaveEsmtAppSignatoryCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        IEsmtAppSignatoryRepository repoSignatory
        //ITermBrokenRuleRepository repoBrokenRules
    ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoSignatory = repoSignatory;
        //this.repoBrokenRules = repoBrokenRules;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(SaveEsmtAppSignatoryCommand request, CancellationToken cancellationToken)
    {
        int signatoryId = 0;

        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // map command object to the FarmEsmtAppSignatoryEntity
        var reqSignatory = mapper.Map<SaveEsmtAppSignatoryCommand, FarmEsmtAppSignatoryEntity>(request);

        // Check Broken Rules
        var brokenRules = ReturnBrokenRulesIfAny(reqSignatory);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            // Delete old Broken Rules, if any
            //await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, EsmtAppSectionEnum.SIGNATORY);
            // Save current Broken Rules, if any
            //await repoBrokenRules.SaveBrokenRules(brokenRules);

            var signatory = await repoSignatory.SaveAsync(reqSignatory);
            if (signatory != null)
            {
                signatoryId = signatory.Id;
            }

            scope.Complete();

        }

        return signatoryId;
    }

    private List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmEsmtAppSignatoryEntity reqSignatory)
    {
        int sectionId = (int)EsmtAppSectionEnum.SIGNATORY;
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();

        // add based on the empty check conditions
        if (string.IsNullOrEmpty(reqSignatory.AmountPerAcre.ToString()))
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = reqSignatory.ApplicationId,
                SectionId = sectionId,
                Message = "AmountPerAcre required field on Signatory tab have not been filled.",
                IsApplicantFlow = true
            });

        if (string.IsNullOrEmpty(reqSignatory.Designation))
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = reqSignatory.ApplicationId,
                SectionId = sectionId,
                Message = "Designation required field on Signatory tab have not been filled.",
                IsApplicantFlow = true
            });

        if (string.IsNullOrEmpty(reqSignatory.Title))
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = reqSignatory.ApplicationId,
                SectionId = sectionId,
                Message = "Title required field on Signatory tab have not been filled.",
                IsApplicantFlow = true
            });

        if (reqSignatory.SignedOn == null)
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = reqSignatory.ApplicationId,
                SectionId = sectionId,
                Message = "Date required field on Signatory tab have not been filled.",
                IsApplicantFlow = true
            });

        return brokenRules;
    }
}
