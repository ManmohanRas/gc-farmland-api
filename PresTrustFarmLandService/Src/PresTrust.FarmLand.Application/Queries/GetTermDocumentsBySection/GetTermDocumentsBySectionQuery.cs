namespace PresTrust.FarmLand.Application.Queries;

public class GetTermDocumentsBySectionQuery : IRequest<IEnumerable<TermDocumentTypeViewModel>>
{
    public int ApplicationId { get; set; }
    public string SectionName { get; set; }
}
