namespace PresTrust.FarmLand.Application.Commands;
public class SaveTermAppSignatoryCommandHandler : BaseHandler, IRequestHandler<SaveTermAppSignatoryCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    //private readonly IApplicationFeedbackRepository repoFeedback;
    private ITermAppSignatoryRepository repoSignatory;
    //private readonly IBrokenRuleRepository repoBrokenRules;


    public SaveTermAppSignatoryCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        ITermAppSignatoryRepository repoSignatory
        //IApplicationFeedbackRepository repoFeedback,
        //IBrokenRuleRepository repoBrokenRules
    ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoSignatory = repoSignatory;
        //this.repoFeedback = repoFeedback;
        //this.repoBrokenRules = repoBrokenRules;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(SaveTermAppSignatoryCommand request, CancellationToken cancellationToken)
    {
        int signatoryId = 0;

        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // map command object to the FarmTermAppSignatoryEntity
        var reqSignatory = mapper.Map<SaveTermAppSignatoryCommand, FarmTermAppSignatoryEntity>(request);

        // Check Broken Rules
        //var brokenRules = ReturnBrokenRulesIfAny(reqSignatory);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            // Delete old Broken Rules, if any
            //await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, ApplicationSectionEnum.SIGNATORY);
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

    //private List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmTermAppSignatoryEntity reqSignatory)
    //{
    //    int sectionId = (int)ApplicationSectionEnum.SIGNATORY;
    //    List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();

    //    // add based on the empty check conditions
    //    if (string.IsNullOrEmpty(reqSignatory.Designation))
    //        brokenRules.Add(new FarmBrokenRuleEntity()
    //        {
    //            ApplicationId = reqSignatory.ApplicationId,
    //            SectionId = sectionId,
    //            Message = "Designation required field on Signatory tab have not been filled.",
    //            IsApplicantFlow = true
    //        });

    //    if (string.IsNullOrEmpty(reqSignatory.Title))
    //        brokenRules.Add(new FarmBrokenRuleEntity()
    //        {
    //            ApplicationId = reqSignatory.ApplicationId,
    //            SectionId = sectionId,
    //            Message = "Title required field on Signatory tab have not been filled.",
    //            IsApplicantFlow = true
    //        });

    //    if (reqSignatory.SignedOn == null)
    //        brokenRules.Add(new FarmBrokenRuleEntity()
    //        {
    //            ApplicationId = reqSignatory.ApplicationId,
    //            SectionId = sectionId,
    //            Message = "Date required field on Signatory tab have not been filled.",
    //            IsApplicantFlow = true
    //        });

    //    return brokenRules;
    //}
}

