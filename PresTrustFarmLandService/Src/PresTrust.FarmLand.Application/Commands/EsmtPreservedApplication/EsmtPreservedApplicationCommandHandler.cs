using PresTrust.FarmLand.Application.Queries;

namespace PresTrust.FarmLand.Application.Commands;

public class EsmtPreservedApplicationCommandHandler : BaseHandler, IRequestHandler<EsmtPreservedApplicationCommand, EsmtPreservedApplicationCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    private readonly IApplicationLocationRepository repoLocation;
    private readonly IEmailTemplateRepository repoEmailTemplate;
    private readonly IEmailManager repoEmailManager;
    private readonly IOwnerDetailsRepository repoOwner

    public EsmtPreservedApplicationCommandHandler 
    (
      IMapper mapper,
      IPresTrustUserContext userContext,
      IOptions<SystemParameterConfiguration> systemParamOptions,
      IApplicationRepository repoApplication,
      ITermBrokenRuleRepository repoBrokenRules,
      IApplicationLocationRepository repoLocation,
      IEmailTemplateRepository repoEmailTemplate,
      IEmailManager repoEmailManager,
      IOwnerDetailsRepository repoOwner
    ) : base(repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoBrokenRules = repoBrokenRules;
        this.repoLocation = repoLocation;
        this.repoEmailTemplate = repoEmailTemplate;
        this.repoEmailManager = repoEmailManager;
        this.repoOwner  = repoOwner;
    }

    public async Task<EsmtPreservedApplicationCommandViewModel> Handle(EsmtPreservedApplicationCommand request, CancellationToken cancellationToken)
    {
        EsmtPreservedApplicationCommandViewModel result = new();
        IEnumerable<OwnerDetailsEntity> ownerDetails;
        FarmBlockLotEntity blockLot = new FarmBlockLotEntity();


        // check if application exists
        var application = await GetIfApplicationExists(request.ApplicationId);

        //update application
        if (application != null)
        {
            application.StatusId = (int)EsmtAppStatusEnum.PRESERVED;
            application.LastUpdatedBy = userContext.Email;
        }

        // check if any broken rules exists, if yes then return
        var brokenRules = (await repoBrokenRules.GetBrokenRulesAsync(application.Id));

        if (brokenRules != null && brokenRules.Any())
        {
            result.BrokenRules = mapper.Map<IEnumerable<FarmBrokenRuleEntity>, IEnumerable<BrokenRuleViewModel>>(brokenRules);
            return result;
        }
        ownerDetails = await repoOwner.GetOwnerDetailsAsync(request.ApplicationId);

        var locationDetails = await repoLocation.GetParcelsByFarmID(application.Id, application.FarmListId);
        blockLot = locationDetails.Where(x => x.IsChecked).FirstOrDefault();

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            // returns broken rules  
            var defaultBrokenRules = ReturnBrokenRulesIfAny(application);
            // save broken rules
            await repoBrokenRules.SaveBrokenRules(defaultBrokenRules);

            await repoApplication.UpdateApplicationStatusAsync(application, EsmtAppStatusEnum.PRESERVED);
            FarmApplicationStatusLogEntity appStatusLog = new()
            {
                ApplicationId = application.Id,
                StatusId = application.StatusId,
                StatusDate = DateTime.Now,
                Notes = string.Empty,
                LastUpdatedBy = application.LastUpdatedBy
            };
            await repoApplication.SaveStatusLogAsync(appStatusLog);

            var template = await repoEmailTemplate.GetEmailTemplate(EmailTemplateCodeTypeEnum.CHANGE_STATUS_FROM_IN_POST_CLOSING_TO_PRESERVED.ToString());
            if (template != null)
                await repoEmailManager.SendMail(subject: template.Subject, applicationId: application.Id, applicationName: application.Title, htmlBody: template.Description, agencyId: application.AgencyId, owner: ownerDetails.FirstOrDefault(), blockLot: blockLot);

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
    private List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmApplicationEntity application)
    {
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();

        //List<FarmTermAppLocationEntity> locationDeatils = new List<FarmTermAppLocationEntity>();

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
