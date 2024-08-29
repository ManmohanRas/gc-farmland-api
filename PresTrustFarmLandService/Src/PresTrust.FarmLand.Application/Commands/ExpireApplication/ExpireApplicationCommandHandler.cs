namespace PresTrust.FarmLand.Application.Commands;

public class ExpireApplicationCommandHandler : BaseHandler, IRequestHandler<ExpireApplicationCommand, Unit>
{
    private IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermBrokenRuleRepository repoBrokenRules;

    public ExpireApplicationCommandHandler(IMapper mapper,
         IPresTrustUserContext userContext,
         IOptions<SystemParameterConfiguration> systemParamOptions,
         IApplicationRepository repoApplication,
         ITermBrokenRuleRepository repoBrokenRules
         ) : base(repoApplication: repoApplication)
    {
         this.mapper = mapper;
         this.userContext = userContext;
         this.systemParamOptions = systemParamOptions.Value;
         this.repoApplication = repoApplication;
         this.repoBrokenRules = repoBrokenRules;
    }
    public async Task<Unit> Handle(ExpireApplicationCommand request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // update application status
        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            await repoApplication.UpdateApplicationStatusAsync(application, TermAppStatusEnum.EXPIRED);
            scope.Complete();
        };

        return Unit.Value;
    }
}
