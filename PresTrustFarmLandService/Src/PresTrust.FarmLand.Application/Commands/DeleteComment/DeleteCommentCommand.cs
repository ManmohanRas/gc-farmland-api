namespace PresTrust.FarmLand.Application.Commands;

public class DeleteCommentCommand : IRequest<bool>
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
}
