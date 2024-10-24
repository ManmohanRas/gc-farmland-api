

namespace PresTrust.FarmLand.Application.Commands;
public class EsmtRejectApplicationCommandHandler :BaseHandler,IRequestHandler<EsmtRejectApplicationCommand,Unit>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly IApplicationRepository repoApplication;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly ITermBrokenRuleRepository repoBrokenRules;



    public EsmtRejectApplicationCommandHandler
        (IMapper mapper,
        IPresTrustUserContext userContext, 
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
         ITermBrokenRuleRepository repoBrokenRules) :base(repoApplication)
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
    public async Task<Unit> Handle(EsmtRejectApplicationCommand request, CancellationToken cancellationToken)
    {
        var application = await repoApplication.GetApplicationAsync(request.ApplicationId);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            await repoApplication.UpdateApplicationStatusAsync(application, EsmtAppStatusEnum.REJECTED);
            await repoBrokenRules.DeleteAllBrokenRulesAsync(application.Id);
            scope.Complete();
        }

        return Unit.Value;
    }
}
