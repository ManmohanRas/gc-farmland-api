namespace PresTrust.FarmLand.Application.Commands;

public class RejectApplicationCommandHandler : BaseHandler, IRequestHandler<RejectApplicationCommand, Unit>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly IApplicationRepository repoApplication;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly ITermBrokenRuleRepository repoBrokenRules;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="repoApplication"></param>
    public RejectApplicationCommandHandler
    (
         IMapper mapper,
         IPresTrustUserContext userContext,
         IOptions<SystemParameterConfiguration> systemParamOptions,
         IApplicationRepository repoApplication,
         ITermBrokenRuleRepository repoBrokenRules
    ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.repoApplication = repoApplication;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoBrokenRules = repoBrokenRules;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(RejectApplicationCommand request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // update application status
        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            await repoBrokenRules.DeleteAllBrokenRulesAsync(application.Id);
            await repoApplication.UpdateApplicationStatusAsync(application, TermAppStatusEnum.REJECTED);
            

            scope.Complete();
        };

        return Unit.Value;
    }
}
