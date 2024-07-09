namespace PresTrust.FarmLand.Application.Commands;

public class RejectApplicationCommand : IRequest<Unit>
{
    public int ApplicationId { get; set; }
}
