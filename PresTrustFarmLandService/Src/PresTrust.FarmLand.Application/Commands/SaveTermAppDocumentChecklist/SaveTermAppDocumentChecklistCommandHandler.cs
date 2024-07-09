namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppDocumentChecklistCommandHandler : BaseHandler , IRequestHandler<SaveTermAppDocumentChecklistCommand, Unit>
{
    private IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermOtherDocumentsRepository repoDocument;

    public SaveTermAppDocumentChecklistCommandHandler
       (
           IMapper mapper,
           IPresTrustUserContext userContext,
           IOptions<SystemParameterConfiguration> systemParamOptions,
           IApplicationRepository repoApplication,
           ITermOtherDocumentsRepository repoDocument
       ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoDocument = repoDocument;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(SaveTermAppDocumentChecklistCommand request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // consider only add/updated records
        var viewmodelDocuments = request.Documents.Where(doc => string.Compare(doc.RowStatus, "U", ignoreCase: true) == 0).ToList();

        // map command object to the HistDocumentEntity
        var entityDocuments = mapper.Map<IEnumerable<TermDocumentsViewModel>, IEnumerable<TermOtherDocumentsEntity>>(viewmodelDocuments);


        // save application documents, property documents (review/checklist items)
        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            foreach (var doc in entityDocuments)
            {
                await repoDocument.SaveTermDocumentChecklistAsync(doc);
            }
            //await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, ApplicationSectionEnum.ADMIN_DOCUMENT_CHECKLIST);
            //await repoBrokenRules.SaveBrokenRules(await brokenRules);

            scope.Complete();
        };

        return Unit.Value;
    }

}
