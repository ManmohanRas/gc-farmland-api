namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppAdminDeedDetailsCommandHandler : BaseHandler, IRequestHandler<SaveTermAppAdminDeedDetailsCommand , Unit>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermAppAdminDeedDetailsRepository repotermAppAdminDeedDetails;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly ITermOtherDocumentsRepository repoDocuments;


    public SaveTermAppAdminDeedDetailsCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        ITermAppAdminDeedDetailsRepository repotermAppAdminDeedDetails,
        ITermBrokenRuleRepository repoBrokenRules,
        ITermOtherDocumentsRepository repoDocuments
    ) : base(repoApplication:repoApplication)
    { 
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repotermAppAdminDeedDetails = repotermAppAdminDeedDetails;
        this.repoBrokenRules = repoBrokenRules;
        this.repoDocuments = repoDocuments;
    }

    public async Task<Unit> Handle(SaveTermAppAdminDeedDetailsCommand request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);
        
        var reqDeedDetails = mapper.Map<List<SaveTermAppAdminDeedListCommand>, List<TermAppAdminDeedDetailsEntity>>(request.DeedDetails);

        var brokenRules = await ReturnBrokenRulesIfAny(application, reqDeedDetails);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, TermAppSectionEnum.ADMIN_DEED_DETAILS);
            await repoBrokenRules.SaveBrokenRules(brokenRules);
            foreach (var deed in reqDeedDetails)
            {
                deed.LastUpdatedBy = userContext.Email;
                await repotermAppAdminDeedDetails.SaveAsync(deed);
            }
            
            scope.Complete();

        }

        return Unit.Value;
    }

    private async Task<List<FarmBrokenRuleEntity>> ReturnBrokenRulesIfAny(FarmApplicationEntity application,  List<TermAppAdminDeedDetailsEntity> reqDeedDetails)
    {
        int sectionId = (int)TermAppSectionEnum.ADMIN_DEED_DETAILS;
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();

        var documents = await repoDocuments.GetTermDocumentsAsync(application.Id, sectionId);
      
        if (application.Status == TermAppStatusEnum.PETITION_REQUEST)
        {
            if (documents.Where(o => o.DocumentTypeId == (int)ApplicationDocumentTypeEnum.TRUE_COPY_OF_DEED).Count() == 0)
            {
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = (int)TermAppSectionEnum.ADMIN_DEED_DETAILS,
                    Message = "True Copy Of Deed required document on Deed Details tab have not been Uploaded."
                });
            }
            if (documents.Where(o => o.DocumentTypeId == (int)ApplicationDocumentTypeEnum.COPY_OF_OWNER_OF_LAST_RECORD_SEARCH).Count() == 0)
            {
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = (int)TermAppSectionEnum.ADMIN_DEED_DETAILS,
                    Message = "Copy Of Owner required document on Deed Details tab have not been Uploaded.",
                });
            }

        }

        if (application.Status == TermAppStatusEnum.PETITION_APPROVED)
        {
            foreach (var deed in reqDeedDetails) 
            {
                if (string.IsNullOrEmpty(deed.NOTBook))
                {

                    brokenRules.Add(new FarmBrokenRuleEntity()
                    {
                        ApplicationId = application.Id,
                        SectionId = sectionId,
                        Message = "Notice Of Termination Book required field on Deed Details Tab have not been filled.",
                        IsApplicantFlow = false
                    });

                }
                if (string.IsNullOrEmpty(deed.NOTPage))
                {

                    brokenRules.Add(new FarmBrokenRuleEntity()
                    {
                        ApplicationId = application.Id,
                        SectionId = sectionId,
                        Message = "Notice Of Termination Page required field on Deed Details Tab have not been filled.",
                        IsApplicantFlow = false
                    });

                }
                if (string.IsNullOrEmpty(deed.RDBook))
                {

                    brokenRules.Add(new FarmBrokenRuleEntity()
                    {
                        ApplicationId = application.Id,
                        SectionId = sectionId,
                        Message = "Renewal Deed Book  required field on Deed Details Tab have not been filled.",
                        IsApplicantFlow = false
                    });

                }
                if (string.IsNullOrEmpty(deed.RDPage))
                {

                    brokenRules.Add(new FarmBrokenRuleEntity()
                    {
                        ApplicationId = application.Id,
                        SectionId = sectionId,
                        Message = "Renewal Deed Page required field on Deed Details Tab have not been filled.",
                        IsApplicantFlow = false
                    });

                }
            }
            
        }      


        return brokenRules;
    }

}
