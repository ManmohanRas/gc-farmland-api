namespace PresTrust.FarmLand.Application.Commands;

public class EsmtPendingApplicationCommand : IRequest<EsmtPendingApplicationCommandViewModel>
{
    public int ApplicationId { get; set; }
}
