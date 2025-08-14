namespace PresTrust.FarmLand.Application.Commands;

public class ApproveApplicationCommand : IRequest<ApproveApplicationCommandViewModel>
{
    public int ApplicationId { get; set; }
    public string UserId { get; set; }
}
