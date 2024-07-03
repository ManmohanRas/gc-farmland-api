namespace PresTrust.FarmLand.Application.Queries;

public class GetTermDocumentChecklistQuery : IRequest<IEnumerable<TermDocumentChecklistViewModel>>
{
    public int ApplicationId { get; set; }
}
