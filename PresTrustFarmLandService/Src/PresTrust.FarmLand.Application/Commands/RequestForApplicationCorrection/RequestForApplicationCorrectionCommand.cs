namespace PresTrust.FarmLand.Application.Commands;

public class RequestForApplicationCorrectionCommand : IRequest<bool>
{
    public int ApplicationId { get; set; }
    public string UserId { get; set; }
}
