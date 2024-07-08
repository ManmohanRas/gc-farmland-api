namespace PresTrust.FarmLand.Application.Commands;

public class ExpireApplicationCommand : IRequest<Unit>
{
    public int ApplicationId { get; set; }
}
