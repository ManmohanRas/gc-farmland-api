namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppDocumentChecklistCommand : IRequest<Unit>
{
    public int ApplicationId { get; set; }
    public IEnumerable<TermDocumentsViewModel> Documents { get; set; }
}
