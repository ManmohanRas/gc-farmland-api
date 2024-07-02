namespace PresTrust.FarmLand.Application.Commands;

public class DeleteTermAppDocumentCommandHandler : IRequestHandler<DeleteTermAppDocumentCommand , bool>
{
    private readonly ITermOtherDocumentsRepository repoDocument;

    public DeleteTermAppDocumentCommandHandler
        (
        ITermOtherDocumentsRepository repoDocument
        )
    {
        this.repoDocument = repoDocument;
    }

    public async Task<bool> Handle(DeleteTermAppDocumentCommand request, CancellationToken cancellationToken)
    {
        // delete document
        await repoDocument.DeleteApplicationDocumentAsync(request.Id);

        return true;
    }
}
