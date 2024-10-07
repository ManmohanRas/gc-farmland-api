namespace PresTrust.FarmLand.Application.Commands;

public class EsmtSubmitApplicationCommandHandler : BaseHandler, IRequestHandler<EsmtSubmitApplicationCommand, EsmtSubmitApplicationCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermBrokenRuleRepository repoBrokenRules;

    public EsmtSubmitApplicationCommandHandler
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// 
    public async Task<EsmtSubmitApplicationCommandViewModel> Handle(EsmtSubmitApplicationCommand request, CancellationToken cancellationToken)
    {
        EsmtSubmitApplicationCommandViewModel result = new();

        // check if application exists
        var application = await GetIfApplicationExists(request.ApplicationId);
        //AuthorizationCheck(application);


        //update application
        if (application != null)
        {
            application.StatusId = (int)EsmtAppStatusEnum.APPLICATION_SUBMITTED;
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
            // returns broken rules  
           // var defaultBrokenRules = ReturnBrokenRulesIfAny(application);

            // save broken rules
           // await repoBrokenRules.SaveBrokenRules(defaultBrokenRules);
            await repoApplication.UpdateApplicationStatusAsync(application, EsmtAppStatusEnum.APPLICATION_SUBMITTED);
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

}
