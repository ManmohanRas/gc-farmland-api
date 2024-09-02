namespace PresTrust.FarmLand.Application.Commands;

public class SaveAppDocumentChecklistCommand : IRequest<Unit>
{
    public int ApplicationId { get; set; }
    public IEnumerable<DocumentsViewModel> Documents { get; set; }
}
