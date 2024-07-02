namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppDocumentCommandHandler : IRequestHandler<SaveTermAppDocumentCommand , SaveTermAppDocumentCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly ITermOtherDocumentsRepository repoDocument;

    public SaveTermAppDocumentCommandHandler
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

    public async Task<SaveTermAppDocumentCommandViewModel> Handle(SaveTermAppDocumentCommand request, CancellationToken cancellationToken)
    {
        // map command object to the HistDocumentEntity
        var reqDocument = mapper.Map<SaveTermAppDocumentCommand, TermOtherDocumentsEntity>(request);
        reqDocument.LastUpdatedBy = userContext.Email;

        var entityDocument = await repoDocument.SaveTermDocumentDetailsAsync(reqDocument);

        // map entity object to the SaveDocumentCommandViewModel
        var Document = mapper.Map<TermOtherDocumentsEntity, SaveTermAppDocumentCommandViewModel>(entityDocument);

        return Document;
    }
}
