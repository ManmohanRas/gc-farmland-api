namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppAdminDetailsCommandHandler :BaseHandler, IRequestHandler<SaveTermAppAdminDetailsCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private ITermAppAdminDetailsRepository repoTermAppAdminDetails;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    private readonly ITermOtherDocumentsRepository repoDocument;


    public SaveTermAppAdminDetailsCommandHandler(
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        ITermAppAdminDetailsRepository repoTermAppAdminDetails,
        ITermOtherDocumentsRepository repoDocument,
        ITermBrokenRuleRepository repoBrokenRules
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoTermAppAdminDetails = repoTermAppAdminDetails;
        this.repoBrokenRules = repoBrokenRules;
        this.repoDocument = repoDocument;
    }

    public async Task<int> Handle(SaveTermAppAdminDetailsCommand request, CancellationToken cancellationToken)
    {

        var application = await GetIfApplicationExists(request.ApplicationId);

        var reqTermAppAdminDetails = mapper.Map<SaveTermAppAdminDetailsCommand, FarmTermAppAdminDetailsEntity>(request);

        var brokenRules = await ReturnBrokenRulesIfAny(application, request);
        FarmTermAppAdminDetailsEntity appDetails = default;

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            appDetails = await repoTermAppAdminDetails.SaveTermAppAdminDetailsAsync(reqTermAppAdminDetails);
            await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, TermAppSectionEnum.ADMIN_DETAILS);
            await repoBrokenRules.SaveBrokenRules(brokenRules);

            scope.Complete();

        }

        return appDetails.Id;
    }


    private async Task<List<FarmBrokenRuleEntity>> ReturnBrokenRulesIfAny(FarmApplicationEntity application, SaveTermAppAdminDetailsCommand request)
    {


        int sectionId =  (int)TermAppSectionEnum.ADMIN_DETAILS;
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();


        var documents  =  await repoDocument.GetTermDocumentsAsync(application.Id,sectionId);
        TermOtherDocumentsEntity docsMunicipalOrdinance = default;
        TermOtherDocumentsEntity docsMafppAgreement = default;
        TermOtherDocumentsEntity docsCountyResolution = default;
        TermOtherDocumentsEntity docsSadcApprovalLetter = default;
        TermOtherDocumentsEntity docsReceiptOfCertification = default;
        TermOtherDocumentsEntity docsNotificationOfTermination = default;

        if (documents != null && documents.Count() > 0)
        {
            docsMunicipalOrdinance = documents.Where(d => d.DocumentTypeId  == (int)ApplicationDocumentTypeEnum.MUNICIPAL_ORDINANCE).FirstOrDefault();
            docsMafppAgreement = documents.Where(d => d.DocumentTypeId == (int)ApplicationDocumentTypeEnum.MAFPP_AGREEMENT).FirstOrDefault();
            docsCountyResolution = documents.Where(d => d.DocumentTypeId == (int)ApplicationDocumentTypeEnum.COUNTY_RESOLUTION).FirstOrDefault();
            docsSadcApprovalLetter = documents.Where(d => d.DocumentTypeId == (int)ApplicationDocumentTypeEnum.SADC_APPROVAL_LETTER).FirstOrDefault();
            docsReceiptOfCertification = documents.Where(d => d.DocumentTypeId == (int)ApplicationDocumentTypeEnum.RECEIPT_OF_CERTIFICATION).FirstOrDefault();
            docsNotificationOfTermination = documents.Where (d => d.DocumentTypeId == (int)ApplicationDocumentTypeEnum.NOTIFICATION_OF_TERMINATION).FirstOrDefault();
        }

        if(application.Status == TermAppStatusEnum.PETITION_REQUEST)
        { 
        if (docsMafppAgreement == null)
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = application.Id,
                SectionId = sectionId,
                Message = "Mafpp Agreement required document on AdminDetails tab have not been filled.",
                IsApplicantFlow = false
            });

            if (docsMunicipalOrdinance == null)
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Municipal Ordinance required document on AdminDetails tab have not been filled.",
                    IsApplicantFlow = false
                });

            if (docsCountyResolution == null)
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "County Resolution required document on AdminDetails tab have not been filled.",
                    IsApplicantFlow = false
                });

            if (docsSadcApprovalLetter == null)
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Sadc Approval Letter required document on AdminDetails tab have not been filled.",
                    IsApplicantFlow = false
                });

        }

        if (application.Status == TermAppStatusEnum.WITHDRAWN)
        {
            if (docsNotificationOfTermination == null)
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Notification Of Termination Letter required document on AdminDetails tab have not been filled.",
                    IsApplicantFlow = false
                });
        }

        if (application.Status == TermAppStatusEnum.PETITION_APPROVED)
        {
            if (request?.SADCId == null)
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "SADC ID required field on AdminDetails tab have not been filled.",
                    IsApplicantFlow = false,
                });

            if (request?.MaxGrant == null)
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "MaxGrant ID required field on AdminDetails tab have not been filled.",
                    IsApplicantFlow = false,
                });

            if (request?.PermanentlyPreserved == false)
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Permanently Preserved required field on AdminDetails tab have not been filled.",
                    IsApplicantFlow = false,
                });
            if (request?.MunicipallyApproved == false)
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Municipally Approved required field on AdminDetails tab have not been filled.",
                    IsApplicantFlow = false,
                });
            if (request.EnrollmentDate == null)
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Enrollment Date required field on AdminDetails tab have not been filled.",
                    IsApplicantFlow = false,
                });
            if (request.RenewalDate == null)
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Renewal Date required field on AdminDetails tab have not been filled.",
                    IsApplicantFlow = false,
                });

            if (request.ExpirationDate == null)
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Expiration Date required field on AdminDetails tab have not been filled.",
                    IsApplicantFlow = false,
                });

            if (request.RenewalExpirationDate == null)
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Renewal Expiration Date required field on AdminDetails tab have not been filled.",
                    IsApplicantFlow = false,
                });

            if (docsReceiptOfCertification == null)
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Receipt Of Certification Letter required document on AdminDetails tab have not been filled.",
                    IsApplicantFlow = false
                });
        }
        return brokenRules;
    
    }
}
