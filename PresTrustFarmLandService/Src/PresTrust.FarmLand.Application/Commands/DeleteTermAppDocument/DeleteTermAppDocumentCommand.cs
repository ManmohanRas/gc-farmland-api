namespace PresTrust.FarmLand.Application.Commands;

public class DeleteTermAppDocumentCommand : IRequest<bool>
{
    public int ApplicationId { get; set; }
    public int Id { get; set; }
}
