namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppDocumentCommandViewModel
{  
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string FileName { get; set; }
    public string DocumentType { get; set; }
}
