namespace PresTrust.FarmLand.Application.Queries;

public class GetDocumentsBySectionQuery : IRequest<IEnumerable<DocumentTypeViewModel>>
{
    public int ApplicationId { get; set; }
    public string SectionName { get; set; }
}
