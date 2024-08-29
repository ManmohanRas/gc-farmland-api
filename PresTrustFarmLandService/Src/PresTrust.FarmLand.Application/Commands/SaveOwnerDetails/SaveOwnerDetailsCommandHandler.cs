namespace PresTrust.FarmLand.Application.Commands;

public class SaveOwnerDetailsCommandHandler : BaseHandler, IRequestHandler<SaveOwnerDetailsCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private IOwnerDetailsRepository repoOwner;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    public SaveOwnerDetailsCommandHandler
    (
      IMapper mapper,
      IPresTrustUserContext userContext,
      IOptions<SystemParameterConfiguration> systemParamOptions,
      IApplicationRepository repoApplication,
      IOwnerDetailsRepository repoOwner,
      ITermBrokenRuleRepository repoBrokenRules
    ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoOwner = repoOwner;
        this.repoBrokenRules = repoBrokenRules;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(SaveOwnerDetailsCommand request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        var reqOwner = mapper.Map<SaveOwnerDetailsCommand, OwnerDetailsEntity>(request);

       // var brokenRules = ReturnBrokenRulesIfAny(application);


        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, TermAppSectionEnum.OWNER_DETAILS);
            //await repoBrokenRules.SaveBrokenRules(await brokenRules);
            reqOwner = await repoOwner.SaveOwnerDetailsAsync(reqOwner);
            reqOwner.LastUpdatedBy = userContext.Email;

            scope.Complete();

        }
            return reqOwner.Id;
    }


    private async Task<List<FarmBrokenRuleEntity>> ReturnBrokenRulesIfAny(FarmApplicationEntity application)
    {
        int sectionId = (int)TermAppSectionEnum.OWNER_DETAILS;
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();

        var getDetails = await repoOwner.GetOwnerDetailsAsync(application.Id);


        if (getDetails.Count() == 0)
        {
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = application.Id,
                SectionId = sectionId,
                Message = "At least One Record Should be filled in OwnerDetails Tab.",
                IsApplicantFlow = false,
            });
        }
        return brokenRules;

        }
    }

