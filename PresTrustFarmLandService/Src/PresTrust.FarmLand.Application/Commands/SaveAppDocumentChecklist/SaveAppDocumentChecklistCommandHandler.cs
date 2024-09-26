namespace PresTrust.FarmLand.Application.Commands;

public class SaveAppDocumentChecklistCommandHandler : BaseHandler , IRequestHandler<SaveAppDocumentChecklistCommand, Unit>
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

        // map command object to the HistDocumentEntity
        var entityDocuments = mapper.Map<IEnumerable<DocumentsViewModel>, IEnumerable<TermOtherDocumentsEntity>>(viewmodelDocuments);

        // returns broken rules  
        var brokenRules = ReturnBrokenRulesIfAny(application, request);


        // save application documents, property documents (review/checklist items)
        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            foreach (var doc in entityDocuments)
            {
                await repoDocument.SaveTermDocumentChecklistAsync(doc);
            }
            await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, TermAppSectionEnum.ADMIN_DOCUMENT_CHECKLIST);
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

        int sectionId = (int)TermAppSectionEnum.ADMIN_DOCUMENT_CHECKLIST;
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();
        // map command object to the FloodDocumentEntity
        var documents = mapper.Map<IEnumerable<DocumentsViewModel>, IEnumerable<TermOtherDocumentsEntity>>(request.Documents);

        var unapprovedDocs = documents.Where(doc => doc.Approved == false).ToList();

        if (documents == null || documents.Count() == 0)
        {
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = application.Id,
                SectionId = sectionId,
                Message = "All required documents (Admin-Document-Checklist) are not yet uploaded for committee review.",
                IsApplicantFlow = false
            });
        }

        if (unapprovedDocs != null || unapprovedDocs.Count() > 0)
        {
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = application.Id,
                SectionId = sectionId,
                Message = "All required documents (Admin-Document-Checklist) are not yet approved for committee review.",
                IsApplicantFlow = false
            });
        }

        return brokenRules;
    }

}


