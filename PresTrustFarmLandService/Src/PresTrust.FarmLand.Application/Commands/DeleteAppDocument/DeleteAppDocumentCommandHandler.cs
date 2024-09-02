namespace PresTrust.FarmLand.Application.Commands;

public class DeleteAppDocumentCommandHandler : IRequestHandler<DeleteAppDocumentCommand , bool>
{
    private readonly ITermOtherDocumentsRepository repoDocument;

    public DeleteAppDocumentCommandHandler
        (
        ITermOtherDocumentsRepository repoDocument
        )
    {
        this.repoDocument = repoDocument;
    }

    public async Task<bool> Handle(DeleteAppDocumentCommand request, CancellationToken cancellationToken)
    {
        // delete document
        await repoDocument.DeleteApplicationDocumentAsync(request.Id);

        return true;
    }
}
