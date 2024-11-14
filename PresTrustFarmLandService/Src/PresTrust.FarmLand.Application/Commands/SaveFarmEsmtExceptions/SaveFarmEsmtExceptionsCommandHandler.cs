namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtExceptionsCommandHandler : BaseHandler, IRequestHandler<SaveFarmEsmtExceptionsCommand , int>
{

    private readonly IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    private readonly IFarmEsmtExceptionsRepository repoExceptionsRepository;
    private readonly IFarmEsmtAttachmentBRepository farmEsmtAttachmentBRepository;
    private readonly SystemParameterConfiguration systemParamOptions;

    public SaveFarmEsmtExceptionsCommandHandler(
        IMapper mapper,
        IFarmEsmtExceptionsRepository repoExceptionsRepository,
        IApplicationRepository repoApplication,
         ITermBrokenRuleRepository repoBrokenRules,
         IFarmEsmtAttachmentBRepository repoAttachmentB,
          IOptions<SystemParameterConfiguration> systemParamOptions
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoExceptionsRepository = repoExceptionsRepository;
        this.repoBrokenRules = repoBrokenRules;
        this.farmEsmtAttachmentBRepository = repoAttachmentB;
        this.systemParamOptions = systemParamOptions.Value;

    }

    public async Task<int> Handle( SaveFarmEsmtExceptionsCommand request , CancellationToken cancellationToken )
    {
       
        var application = await GetIfApplicationExists(request.ApplicationId);

        var reqExceptions = mapper.Map<SaveFarmEsmtExceptionsCommand, FarmEsmtExceptionsEntity>(request);
        var brokenRules = ReturnBrokenRulesIfAny(application,reqExceptions);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            reqExceptions = await repoExceptionsRepository.SaveAsync(reqExceptions);

            // Delete old Broken Rules, if any
            await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, EsmtAppSectionEnum.EXCEPTIONS);

            // Save current Broken Rules, if any
            await repoBrokenRules.SaveBrokenRules(brokenRules);


            scope.Complete();
        }

        return reqExceptions.Id;

    }

    private List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmApplicationEntity application,FarmEsmtExceptionsEntity reqExceptions)
    {
        int sectionId = (int)EsmtAppSectionEnum.EXCEPTIONS;
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();

        var attachments = farmEsmtAttachmentBRepository.GetEsmtAttachmentBAsync(application.Id);

        // add based on the empty check conditions
        if (reqExceptions.ExpectedTaxLots == true && attachments.Result.Count() == 0)
        brokenRules.Add(new FarmBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = sectionId,
            Message = "Attachment B is mandatory.",
            IsApplicantFlow = true
        });

        return brokenRules;

    }
}
