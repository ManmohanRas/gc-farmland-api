namespace PresTrust.FarmLand.Application.Commands;

public class ActiveApplicationCommand : IRequest<ActiveApplicationCommandViewModel>
{
    public int ApplicationId { get; set; }
}
