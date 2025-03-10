namespace PresTrust.FarmLand.Application.Commands;

public class EnableSadcCommandHandler : BaseHandler, IRequestHandler<EnableSadcCommand, Unit>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly IEmailTemplateRepository repoEmailTemplate;
    private readonly IEmailManager repoEmailManager;
    private readonly IApplicationLocationRepository repoLocation;
    private readonly ITermBrokenRuleRepository repoBrokenRules;

    public EnableSadcCommandHandler
        (

        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        IEmailTemplateRepository repoEmailTemplate,
        IEmailManager repoEmailManager,
        IApplicationLocationRepository repoLocation,
        ITermBrokenRuleRepository repoBrokenRules

        ) : base (repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoEmailTemplate = repoEmailTemplate;
        this.repoEmailManager = repoEmailManager;
        this.repoLocation = repoLocation;
        this.repoBrokenRules = repoBrokenRules;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(EnableSadcCommand request, CancellationToken cancellationToken)
    {
        FarmBlockLotEntity blockLot = new FarmBlockLotEntity();

        // check if application exists
        var application = await GetIfApplicationExists(request.ApplicationId);

        var locationDetails = await repoLocation.GetParcelsByFarmID(application.Id, application.FarmListId);
        blockLot = locationDetails.Where(x => x.IsChecked).FirstOrDefault();

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            await repoApplication.UpdateSadcAsync(request.ApplicationId);
            //Send Email 
            var template = await repoEmailTemplate.GetEmailTemplate(EmailTemplateCodeTypeEnum.TRIGER_THE_EMAIL_WHEN_SADC_IS_ENABLED.ToString());
            if (template != null)
                await repoEmailManager.SendMail(subject: template.Subject, applicationId: application.Id, applicationName: application.Title, htmlBody: template.Description, agencyId: application.AgencyId, blockLot: blockLot);

            scope.Complete();
        }

        application = await GetIfApplicationExists(request.ApplicationId);
        // Check Broken Rules
        var brokenRules = ReturnBrokenRulesIfAny(application);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            // Delete old Broken Rules, if any
            await repoBrokenRules.DeleteBrokenRulesAsync(request.ApplicationId, TermAppStatusEnum.NONE);

            // Save current Broken Rules, if any
            await repoBrokenRules.SaveBrokenRules(brokenRules);
         

            scope.Complete();
        }

        return Unit.Value;



    }


    private List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmApplicationEntity reqSADC)
    {
        int sectionId = (int)TermAppSectionEnum.NONE;
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();

        // add based on the empty check conditions
        if ((reqSADC.IsSADC == false))
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = reqSADC.Id,
                SectionId = sectionId,
                Message = "SADC toggle should be enabled.",
                IsApplicantFlow = true
            });

        return brokenRules;
    }
}
