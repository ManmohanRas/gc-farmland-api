namespace PresTrust.FarmLand.Application.Commands;

public class SaveAppDocumentCommandHandler : IRequestHandler<SaveAppDocumentCommand , SaveAppDocumentCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly ITermOtherDocumentsRepository repoDocument;

    public SaveAppDocumentCommandHandler
       (
        IMapper mapper,
        IPresTrustUserContext userContext,
        ITermOtherDocumentsRepository repoDocument
       )
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.repoDocument = repoDocument;
    }

    public async Task<SaveAppDocumentCommandViewModel> Handle(SaveAppDocumentCommand request, CancellationToken cancellationToken)
    {
        // map command object to the HistDocumentEntity
        var reqDocument = mapper.Map<SaveAppDocumentCommand, TermOtherDocumentsEntity>(request);
        reqDocument.LastUpdatedBy = userContext.Email;

        var entityDocument = await repoDocument.SaveTermDocumentDetailsAsync(reqDocument);

        // map entity object to the SaveDocumentCommandViewModel
        var Document = mapper.Map<TermOtherDocumentsEntity, SaveAppDocumentCommandViewModel>(entityDocument);

        return Document;
    }
}
