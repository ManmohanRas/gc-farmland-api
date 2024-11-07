
namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppExistUsesCommandHandler : BaseHandler, IRequestHandler<SaveEsmtAppExistUsesCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private IApplicationRepository repoApplication;
    private IEsmtAppExistUsesRepository repoExistUses;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    private readonly IEsmtAppAttachmentERepository repoAttcahmentE;
    private readonly SystemParameterConfiguration systemParamOptions;



    public SaveEsmtAppExistUsesCommandHandler(IMapper mapper,
        IPresTrustUserContext userContext,
        IApplicationRepository repoApplication,
        IEsmtAppExistUsesRepository repoExistUses,
        ITermBrokenRuleRepository repoBrokenRules,
         IEsmtAppAttachmentERepository repoAttcahmentE,
         IOptions<SystemParameterConfiguration> systemParamOptions
        )
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.repoApplication = repoApplication;
        this.repoExistUses = repoExistUses;
        this.repoBrokenRules = repoBrokenRules;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoAttcahmentE = repoAttcahmentE;
    }

    public async Task<int> Handle(SaveEsmtAppExistUsesCommand request, CancellationToken cancellationToken)
    {
        var application = await repoApplication.GetApplicationAsync(request.ApplicationId);
        var reqExist = mapper.Map<SaveEsmtAppExistUsesCommand, EsmtAppExistUsesEntity>(request);
        var brokenRules = ReturnBrokenRulesIfAny(application, reqExist);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes)) 
        {
            // Delete old Broken Rules, if any
            await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, EsmtAppSectionEnum.EXIS_NON_AGRI_USES);
            // Save current Broken Rules, if any
            await repoBrokenRules.SaveBrokenRules(brokenRules);
            reqExist = await repoExistUses.SaveEsmtAppExistUses(reqExist);
            reqExist.LastUpdatedBy = userContext.Email;
            scope.Complete();
        }        
        return reqExist.Id;
    }

    private List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmApplicationEntity application, EsmtAppExistUsesEntity reqExistUses)
    {
        int sectionId = (int)EsmtAppSectionEnum.EXIS_NON_AGRI_USES;
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();

        var attachmentEs = repoAttcahmentE.GetEsmtAppAttachmentEAsync(application.Id);

        if(reqExistUses.IsSubdivisionApproval == true && attachmentEs.Result.Count()==0)
        
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = application.Id,
                SectionId = sectionId,
                Message = "All required fileds in Attachment E must be filled.",
                IsApplicantFlow = true
            });
        
        return brokenRules;
    }


    
}
