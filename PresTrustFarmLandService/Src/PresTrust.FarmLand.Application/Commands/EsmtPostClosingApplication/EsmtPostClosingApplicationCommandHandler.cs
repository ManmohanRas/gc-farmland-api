namespace PresTrust.FarmLand.Application.Commands;

public class EsmtPostClosingApplicationCommandHandler : BaseHandler, IRequestHandler<EsmtPostClosingApplicationCommand, EsmtPostClosingApplicationCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    private readonly IEmailTemplateRepository repoEmailTemplate;
    private readonly IEmailManager repoEmailManager;
    private readonly IOwnerDetailsRepository repoOwner;
    private readonly IApplicationLocationRepository repoLocation;


    public EsmtPostClosingApplicationCommandHandler
  (
    IMapper mapper,
    IPresTrustUserContext userContext,
    IOptions<SystemParameterConfiguration> systemParamOptions,
    IApplicationRepository repoApplication,
    ITermBrokenRuleRepository repoBrokenRules,
    IEmailTemplateRepository repoEmailTemplate,
    IEmailManager repoEmailManager,
    IOwnerDetailsRepository repoOwner,
    IApplicationLocationRepository repoLocation
  ) : base(repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoBrokenRules = repoBrokenRules;
        this.repoEmailManager = repoEmailManager;
        this.repoEmailTemplate = repoEmailTemplate;
        this.repoOwner = repoOwner;
        this.repoLocation = repoLocation;
    }

    public async Task<EsmtPostClosingApplicationCommandViewModel> Handle(EsmtPostClosingApplicationCommand request, CancellationToken cancellationToken)
    {
        EsmtPostClosingApplicationCommandViewModel result = new();
        IEnumerable<OwnerDetailsEntity> ownerDetails;
        FarmBlockLotEntity blockLot = new FarmBlockLotEntity();

        // check if application exists
        var application = await GetIfApplicationExists(request.ApplicationId);

        ownerDetails = await repoOwner.GetOwnerDetailsAsync(request.ApplicationId);

        var locationDetails = await repoLocation.GetParcelsByFarmID(application.Id, application.FarmListId);
        blockLot = locationDetails.Where(x => x.IsChecked).FirstOrDefault();

        //update application
        if (application != null)
        {
            application.StatusId = (int)EsmtAppStatusEnum.POST_CLOSING;
            application.LastUpdatedBy = userContext.Email;
        }

        // check if any broken rules exists, if yes then return
        var brokenRules = (await repoBrokenRules.GetBrokenRulesAsync(application.Id));

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {

            await repoApplication.UpdateApplicationStatusAsync(application, EsmtAppStatusEnum.POST_CLOSING);
            FarmApplicationStatusLogEntity appStatusLog = new()
            {
                ApplicationId = application.Id,
                StatusId = application.StatusId,
                StatusDate = DateTime.Now,
                Notes = string.Empty,
                LastUpdatedBy = application.LastUpdatedBy
            };
            await repoApplication.SaveStatusLogAsync(appStatusLog);

            var template = await repoEmailTemplate.GetEmailTemplate(EmailTemplateCodeTypeEnum.CHANGE_STATUS_FROM_CLOSING_TO_POST_CLOSING.ToString());
            if (template != null)
                await repoEmailManager.SendMail(subject: template.Subject, applicationId: application.Id, applicationName: application.Title, htmlBody: template.Description, agencyId: application.AgencyId, owner: ownerDetails.FirstOrDefault(), blockLot: blockLot);

            // returns broken rules
            var defaultBrokenRules = ReturnBrokenRulesIfAny(application);

            if (defaultBrokenRules.Result.Count() > 0)
            {
                // Save current Broken Rules, if any
                await repoBrokenRules.SaveBrokenRules(await defaultBrokenRules);

            }else
            {
                await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, EsmtAppSectionEnum.LOCATION);
            }

            scope.Complete();
            result.IsSuccess = true;

        }

        return result;
    }

    // <summary>
    /// Return broken rules in case of any business rule failure
    /// </summary>
    /// <param name="request"></param>
    /// <param name="application"></param>
    /// <returns></returns>
    private async Task<List<FarmBrokenRuleEntity>> ReturnBrokenRulesIfAny(FarmApplicationEntity application)
    {
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();

        var locationDeatils = repoLocation.GetParcelsByFarmID(application.Id, application.FarmListId).Result;

        if (locationDeatils.Where(x => !x.IsValidPamsPin).Count() > 0 || locationDeatils.Where(x => x.IsWarning).Count() > 0 || locationDeatils.Where(x => x.IsClassCodeWarning).Count() > 0)
        {
            // add default broken rule while initiating application flow
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = application.Id,
                SectionId = (int)EsmtAppSectionEnum.LOCATION,
                Message = "All warnings must be resolved on Location tab.",

            });

        }
        return brokenRules;
    }

}
