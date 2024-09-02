namespace PresTrust.FarmLand.Application.Commands;

public class DeleteAppDocumentCommand : IRequest<bool>
{
    public int ApplicationId { get; set; }
    public int Id { get; set; }
}
