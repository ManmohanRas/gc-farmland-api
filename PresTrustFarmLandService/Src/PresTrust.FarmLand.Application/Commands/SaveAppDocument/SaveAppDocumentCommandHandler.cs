namespace PresTrust.FarmLand.Application.Commands;

public class SaveAppDocumentCommandHandler : BaseHandler, IRequestHandler<SaveAppDocumentCommand , SaveAppDocumentCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly ITermOtherDocumentsRepository repoDocument;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    private readonly SystemParameterConfiguration systemParamOptions;


    public SaveAppDocumentCommandHandler
       (
        IMapper mapper,
        IPresTrustUserContext userContext,
        ITermOtherDocumentsRepository repoDocument,
        IApplicationRepository repoApplication,
        ITermBrokenRuleRepository repoBrokenRules,
        IOptions<SystemParameterConfiguration> systemParamOptions

       ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.repoDocument = repoDocument;
        this.repoApplication = repoApplication;
        this.repoBrokenRules = repoBrokenRules;
        this.systemParamOptions = systemParamOptions.Value;
    }

    public async Task<SaveAppDocumentCommandViewModel> Handle(SaveAppDocumentCommand request, CancellationToken cancellationToken)
    {

        var application = await GetIfApplicationExists(request.ApplicationId);
        var response = new SaveAppDocumentCommandViewModel();

        // map command object to the OtherDocumentsEntity
        var reqDocument = mapper.Map<SaveAppDocumentCommand, TermOtherDocumentsEntity>(request);
        reqDocument.LastUpdatedBy = userContext.Email;

        // map entity object to the SaveDocumentCommandViewModel


        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            var entityDocument = await repoDocument.SaveTermDocumentDetailsAsync(reqDocument);
            response = mapper.Map<TermOtherDocumentsEntity, SaveAppDocumentCommandViewModel>(entityDocument);
            var brokenRules = ReturnBrokenRulesIfAny(application);

            await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, EsmtAppSectionEnum.OTHER_DOCUMENTS);

            // Save current Broken Rules, if any
            await repoBrokenRules.SaveBrokenRules(brokenRules);
            scope.Complete();
        }

        return response;
    }

    private List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmApplicationEntity application)
    {
        int sectionId = (int)EsmtAppSectionEnum.OTHER_DOCUMENTS;
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();
        TermOtherDocumentsEntity attachmentsF = default;
        TermOtherDocumentsEntity attachmentsG = default;
        TermOtherDocumentsEntity attachmentsH = default;
        TermOtherDocumentsEntity landOwnerDocs = default;


        var documents = repoDocument.GetTermDocumentsAsync(application.Id, sectionId).Result;

        if (documents != null)
        {
            landOwnerDocs = documents.Where(d => d.DocumentTypeId == (int)ApplicationDocumentTypeEnum.ESMT_LANDOWNER_SIGNATURE).FirstOrDefault();
            attachmentsF = documents.Where(d => d.DocumentTypeId == (int)ApplicationDocumentTypeEnum.ATTACHMENT_F).FirstOrDefault();
            attachmentsG = documents.Where(d => d.DocumentTypeId == (int)ApplicationDocumentTypeEnum.ATTACHMENT_G).FirstOrDefault();
            attachmentsH = documents.Where(d => d.DocumentTypeId == (int)ApplicationDocumentTypeEnum.ATTACHMENT_H).FirstOrDefault();
        }

        if (application.ApplicationType == ApplicationTypeEnum.EASEMENT)
        {
            if (attachmentsF == null)
            {
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = (int)EsmtAppSectionEnum.OTHER_DOCUMENTS,
                    Message = "Attachment F is mandatory.",
                    IsApplicantFlow = true
                });
            }

            if (attachmentsG == null)
            {
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = (int)EsmtAppSectionEnum.OTHER_DOCUMENTS,
                    Message = "Attachment G is mandatory.",
                    IsApplicantFlow = true
                });
            }

            if (attachmentsH == null)
            {
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = (int)EsmtAppSectionEnum.OTHER_DOCUMENTS,
                    Message = "Attachment H is mandatory.",
                    IsApplicantFlow = true
                });
            }

            if (landOwnerDocs == null)
            {
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = (int)EsmtAppSectionEnum.OTHER_DOCUMENTS,
                    Message = "Landowner Signature is mandatory.",
                    IsApplicantFlow = true
                });
            }
        }

        return brokenRules;
    }
}
