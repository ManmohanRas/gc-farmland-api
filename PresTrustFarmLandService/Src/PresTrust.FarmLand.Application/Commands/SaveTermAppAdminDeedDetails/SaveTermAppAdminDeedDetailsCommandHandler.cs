
namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppAdminDeedDetailsCommandHandler : BaseHandler, IRequestHandler<SaveTermAppAdminDeedDetailsCommand , int>
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

    public async Task<int> Handle(SaveTermAppAdminDeedDetailsCommand request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);
        
        var reqDeedDetails = mapper.Map<SaveTermAppAdminDeedDetailsCommand, TermAppAdminDeedDetailsEntity>(request);

        var brokenRules = await ReturnBrokenRulesIfAny(application, reqDeedDetails);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, ApplicationSectionEnum.ADMIN_DEED_DETAILS);
            await repoBrokenRules.SaveBrokenRules(brokenRules);
            reqDeedDetails = await repotermAppAdminDeedDetails.SaveAsync(reqDeedDetails);
            reqDeedDetails.LastUpdatedBy = userContext.Email;
            scope.Complete();

        }

        return reqDeedDetails.Id;
    }

    private async Task <List<TermBrokenRuleEntity>> ReturnBrokenRulesIfAny(FarmApplicationEntity application, TermAppAdminDeedDetailsEntity reqDeedDetails)
    {
        int sectionId = (int)ApplicationSectionEnum.ADMIN_DEED_DETAILS;
        List<TermBrokenRuleEntity> brokenRules = new List<TermBrokenRuleEntity>();
        if (application.Status == ApplicationStatusEnum.PETITION_APPROVED)
        {
            if (string.IsNullOrEmpty(reqDeedDetails.NOTBlock))
            {

                brokenRules.Add(new TermBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Notice Of Termination Block required field on Deed Details Tab have not been filled.",
                    IsApplicantFlow = false
                });

            }
            if (string.IsNullOrEmpty(reqDeedDetails.NOTLot))
            {

                brokenRules.Add(new TermBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Notice Of Termination Lot required field on Deed Details Tab have not been filled.",
                    IsApplicantFlow = false
                });

            }
            if (string.IsNullOrEmpty(reqDeedDetails.NOTBook))
            {

                brokenRules.Add(new TermBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Notice Of Termination Book required field on Deed Details Tab have not been filled.",
                    IsApplicantFlow = false
                });

            }
            if (string.IsNullOrEmpty(reqDeedDetails.NOTPage))
            {

                brokenRules.Add(new TermBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Notice Of Termination Page required field on Deed Details Tab have not been filled.",
                    IsApplicantFlow = false
                });

            }
            if (string.IsNullOrEmpty(reqDeedDetails.RDBlock))
            {

                brokenRules.Add(new TermBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Renewal Deed Block required field on Deed Details Tab have not been filled.",
                    IsApplicantFlow = false
                });

            }
            if (string.IsNullOrEmpty(reqDeedDetails.RDLot))
            {

                brokenRules.Add(new TermBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Renewal Deed Lot required field on Deed Details Tab have not been filled.",
                    IsApplicantFlow = false
                });

            }
            if (string.IsNullOrEmpty(reqDeedDetails.RDBook))
            {

                brokenRules.Add(new TermBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Renewal Deed Book  required field on Deed Details Tab have not been filled.",
                    IsApplicantFlow = false
                });

            }
            if (string.IsNullOrEmpty(reqDeedDetails.RDPage))
            {

                brokenRules.Add(new TermBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Renewal Deed Page required field on Deed Details Tab have not been filled.",
                    IsApplicantFlow = false
                });

            }
        }      

        return brokenRules;
    }

}
