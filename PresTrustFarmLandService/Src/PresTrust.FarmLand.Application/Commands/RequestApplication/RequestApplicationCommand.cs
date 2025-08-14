namespace PresTrust.FarmLand.Application.Commands;

public class RequestApplicationCommand: IRequest<RequestApplicationCommandViewModel>
{
    public int ApplicationId { get; set; }
    public string UserId { get; set; }
}
