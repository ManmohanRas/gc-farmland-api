namespace PresTrust.FarmLand.Application.Commands;

public class SaveAppDocumentChecklistCommandHandler : BaseHandler, IRequestHandler<SaveAppDocumentChecklistCommand, Unit>
{
    private IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermOtherDocumentsRepository repoDocument;
    private readonly ITermBrokenRuleRepository repoBrokenRules;


    public SaveAppDocumentChecklistCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        ITermOtherDocumentsRepository repoDocument,
        ITermBrokenRuleRepository repoBrokenRules
    ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoDocument = repoDocument;
        this.repoBrokenRules = repoBrokenRules;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(SaveAppDocumentChecklistCommand request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);
        // consider only add/updated records
        var viewmodelDocuments = request.Documents.Where(doc => string.Compare(doc.RowStatus, "U", ignoreCase: true) == 0).ToList();
        var entityDocments= mapper.Map<IEnumerable<DocumentsViewModel>, IEnumerable<TermOtherDocumentsEntity>>(viewmodelDocuments);

        // check if any broken rules exists, if yes then return
        var brokenRules = ReturnBrokenRulesIfAny(application, request);

       

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            foreach (var doc in viewmodelDocuments)
            {
                doc.ApplicationTypeId = application.ApplicationTypeId;
                var mapDoc = mapper.Map<DocumentsViewModel, TermOtherDocumentsEntity>(doc);
                await repoDocument.SaveTermDocumentChecklistAsync(mapDoc);
            }
            if (application.ApplicationTypeId == 1)
            {
                await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, TermAppSectionEnum.ADMIN_DOCUMENT_CHECKLIST);
            }
            else if (application.ApplicationTypeId == 2) 
            {
                await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, EsmtAppSectionEnum.ADMIN_DOCUMENT_CHECK_LIST);

            }
            // Save current Broken Rules, if any
            await repoBrokenRules.SaveBrokenRules(await brokenRules);
            scope.Complete();
        };

        return Unit.Value;
    }

    /// <summary>
    /// Return broken rules in case of any business rule failure
    /// </summary>
    /// <param name="application"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    private async Task<List<FarmBrokenRuleEntity>> ReturnBrokenRulesIfAny(FarmApplicationEntity application, SaveAppDocumentChecklistCommand request)
    {

        int sectionId = application.ApplicationTypeId == 1 ?  (int)TermAppSectionEnum.ADMIN_DOCUMENT_CHECKLIST : (int)EsmtAppSectionEnum.ADMIN_DOCUMENT_CHECK_LIST;
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();
        // map command object to the FarmDocumentEntity
        var documents = mapper.Map<IEnumerable<DocumentsViewModel>,  IEnumerable<TermOtherDocumentsEntity>>(request.Documents);

        var unapprovedDocs = request.Documents.Where(doc => doc.Approved == false).Count();
      
        if (documents == null || documents.Count() == 0)
        {
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = application.Id,
                SectionId = sectionId,
                Message = "All required documents (Admin-Document-Checklist) are not yet uploaded",
                IsApplicantFlow = false
            });
        }

        if (unapprovedDocs == null|| unapprovedDocs > 0)
        {
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = application.Id,
                SectionId = sectionId,
                Message = "All required documents (Admin-Document-Checklist) are not yet approved",
                IsApplicantFlow = false
            });
        }

        return brokenRules;
    }

}

   

  




