namespace PresTrust.FarmLand.Application.Commands;

public class ActiveApplicationCommandHandler : BaseHandler, IRequestHandler<ActiveApplicationCommand, ActiveApplicationCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly IEmailTemplateRepository repoEmailTemplate;
    private readonly IEmailManager repoEmailManager;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    private readonly IOwnerDetailsRepository repoOwner;
    private readonly ITermAppAdminDeedDetailsRepository repoDeedDetails;
    private readonly IApplicationLocationRepository repoLocation;

    public ActiveApplicationCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        IEmailTemplateRepository repoEmailTemplate,
        IEmailManager repoEmailManager,
        ITermBrokenRuleRepository repoBrokenRules,
        IOwnerDetailsRepository repoOwner,
        ITermAppAdminDeedDetailsRepository repoDeedDetails,
        IApplicationLocationRepository repoLocation
    ) : base(repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoEmailTemplate = repoEmailTemplate;
        this.repoEmailManager = repoEmailManager;
        this.repoBrokenRules = repoBrokenRules;
        this.repoOwner = repoOwner;
        this.repoDeedDetails = repoDeedDetails;
        this.repoLocation  = repoLocation;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActiveApplicationCommandViewModel> Handle(ActiveApplicationCommand request, CancellationToken cancellationToken)
    {
        ActiveApplicationCommandViewModel result = new();
        IEnumerable<OwnerDetailsEntity> ownerDetails;
        IEnumerable<TermAppAdminDeedDetailsEntity> deeddetails;
        FarmBlockLotEntity blockLot = new FarmBlockLotEntity();


        // check if application exists
        var application = await GetIfApplicationExists(request.ApplicationId);

        // get Owner Details
        ownerDetails = await repoOwner.GetOwnerDetailsAsync(request.ApplicationId);

        var locationDetails = await repoLocation.GetParcelsByFarmID(application.Id, application.FarmListId);
        blockLot = locationDetails.Where(x => x.IsChecked).FirstOrDefault();

        // get Deed Details
        deeddetails = await repoDeedDetails.GetTermAppAdminDeedDetails(request.ApplicationId);

        //update application
        if (application != null)
        {
            application.StatusId = (int)TermAppStatusEnum.ACTIVE;
            application.LastUpdatedBy = userContext.Email;
        }

        // check if any broken rules exists, if yes then return
        var brokenRules = (await repoBrokenRules.GetBrokenRulesAsync(application.Id))?.ToList();

        if (brokenRules != null && brokenRules.Any())
        {
            result.BrokenRules = mapper.Map<IEnumerable<FarmBrokenRuleEntity>, IEnumerable<BrokenRuleViewModel>>(brokenRules);
            return result;
        }

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            var defaultBrokenRules = ReturnBrokenRulesIfAny(application);
            await repoBrokenRules.SaveBrokenRules(defaultBrokenRules);

            // save broken rules
            await repoApplication.UpdateApplicationStatusAsync(application, TermAppStatusEnum.ACTIVE);
            FarmApplicationStatusLogEntity appStatusLog = new()
            {
                ApplicationId = application.Id,
                StatusId = application.StatusId,
                StatusDate = DateTime.Now,
                Notes = string.Empty,
                LastUpdatedBy = application.LastUpdatedBy
            };
            await repoApplication.SaveStatusLogAsync(appStatusLog);

            //var admindetails = await this.repoTermAppAdminDetailsRepository.GetTermAppAdminDetailsAsync(request.ApplicationId);



            //Send Email 
            var template = await repoEmailTemplate.GetEmailTemplate(EmailTemplateCodeTypeEnum.CHANGE_STATUS_FROM_AGREEMENT_APPROVED_TO_ACTIVE.ToString());
            if (template != null)
                await repoEmailManager.SendMail(subject: template.Subject, applicationId: application.Id, applicationName: application.Title, htmlBody: template.Description, agencyId: application.AgencyId, owner: ownerDetails.FirstOrDefault(), blockLot: blockLot);

            scope.Complete();
            result.IsSuccess = true;
        }

        return result;
    }

    /// <summary>
    /// Return broken rules in case of any business rule failure
    /// </summary>
    /// <param name="request"></param>
    /// <param name="application"></param>
    /// <returns></returns>
    private List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmApplicationEntity application)
    {
        List<FarmBrokenRuleEntity> statusChangeRules = new List<FarmBrokenRuleEntity>();

        statusChangeRules.Add(new FarmBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = (int)TermAppSectionEnum.ADMIN_DETAILS,
            Message = "All required fields on ADMIN DETAILS tab have not been filled.",
        });
        return statusChangeRules;
    }
}
