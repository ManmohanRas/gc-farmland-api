namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppDocumentCommand : IRequest<SaveTermAppDocumentCommandViewModel>
{
    public int ApplicationId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string FileName { get; set; }
    public string DocumentType { get; set; }
}
