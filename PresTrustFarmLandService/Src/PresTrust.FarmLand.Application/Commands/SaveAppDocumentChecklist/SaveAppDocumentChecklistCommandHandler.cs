

namespace PresTrust.FarmLand.Application.Commands;

public class SaveAppDocumentChecklistCommandHandler : BaseHandler , IRequestHandler<SaveAppDocumentChecklistCommand, Unit>
{
    private IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermOtherDocumentsRepository repoDocument;
    //private readonly ISiteRepository repoSite;
    private readonly ITermBrokenRuleRepository repoBrokenRules;


    public SaveAppDocumentChecklistCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        ITermOtherDocumentsRepository repoDocument,
        //ISiteRepository repoSite,
        ITermBrokenRuleRepository repoBrokenRules
    ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoDocument = repoDocument;
        //this.repoSite = repoSite;
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


        // save application documents, property documents (review/checklist items)
        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            foreach (var doc in entityDocuments)
            {
                await repoDocument.SaveTermDocumentChecklistAsync(doc);
            }
            await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, TermAppSectionEnum.ADMIN_DOCUMENT_CHECKLIST);
            scope.Complete();
        };

        return Unit.Value;
    }

    
}
  




