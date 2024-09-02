namespace PresTrust.FarmLand.Application.Queries;

public class GetDocumentChecklistQuery : IRequest<IEnumerable<DocumentChecklistViewModel>>
{
    public int ApplicationId { get; set; }
}
