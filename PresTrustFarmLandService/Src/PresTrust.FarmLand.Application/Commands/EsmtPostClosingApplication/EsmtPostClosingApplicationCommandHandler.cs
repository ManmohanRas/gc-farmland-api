namespace PresTrust.FarmLand.Application.Commands;

public class EsmtPostClosingApplicationCommandHandler : BaseHandler, IRequestHandler<EsmtPostClosingApplicationCommand, EsmtPostClosingApplicationCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermBrokenRuleRepository repoBrokenRules;


    public EsmtPostClosingApplicationCommandHandler
  (
    IMapper mapper,
    IPresTrustUserContext userContext,
    IOptions<SystemParameterConfiguration> systemParamOptions,
    IApplicationRepository repoApplication,
    ITermBrokenRuleRepository repoBrokenRules
  ) : base(repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoBrokenRules = repoBrokenRules;
    }

    public async Task<EsmtPostClosingApplicationCommandViewModel> Handle(EsmtPostClosingApplicationCommand request, CancellationToken cancellationToken)
    {
        EsmtPostClosingApplicationCommandViewModel result = new();

        // check if application exists
        var application = await GetIfApplicationExists(request.ApplicationId);

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
            // returns broken rules  
           // var defaultBrokenRules = ReturnBrokenRulesIfAny(application);
            // save broken rules
           // await repoBrokenRules.SaveBrokenRules(defaultBrokenRules);

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
    //private List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmApplicationEntity application)
    //{
    //    List<FarmBrokenRuleEntity> statusChangeRules = new List<FarmBrokenRuleEntity>();

    //    // add default broken rule while initiating application flow
    //    statusChangeRules.Add(new FarmBrokenRuleEntity()
    //    {
    //        ApplicationId = application.Id,
    //        SectionId = (int)EsmtAppSectionEnum.LOCATION,
    //        Message = "All required fields on ADMIN_DETAILS tab have not been filled.",

    //    });

    //    return statusChangeRules;
    //}
}
