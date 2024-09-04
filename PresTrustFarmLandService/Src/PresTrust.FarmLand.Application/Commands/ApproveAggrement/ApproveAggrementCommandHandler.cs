namespace PresTrust.FarmLand.Application.Commands;

public class ApproveAggrementCommandHandler : BaseHandler, IRequestHandler<ApproveAggrementCommand, ApproveAggrementCommandViewmodel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermBrokenRuleRepository repoBrokenRules;

    public ApproveAggrementCommandHandler
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
    public async Task<ApproveAggrementCommandViewmodel> Handle(ApproveAggrementCommand request, CancellationToken cancellationToken)
    {
        ApproveAggrementCommandViewmodel result = new();

        // check if application exists
        var application = await GetIfApplicationExists(request.ApplicationId);

        //update application
        if (application != null)
        {
            application.StatusId = (int)TermAppStatusEnum.AGREEMENT_APPROVED;
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
            //await repoBrokenRules.SaveBrokenRules(defaultBrokenRules);
            await repoApplication.UpdateApplicationStatusAsync(application, TermAppStatusEnum.AGREEMENT_APPROVED);
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
