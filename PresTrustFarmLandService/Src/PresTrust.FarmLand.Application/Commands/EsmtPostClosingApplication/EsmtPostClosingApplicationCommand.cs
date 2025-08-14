namespace PresTrust.FarmLand.Application.Commands;

public class EsmtPostClosingApplicationCommand : IRequest<EsmtPostClosingApplicationCommandViewModel>
{
    public int ApplicationId { get; set; }
    public string UserId { get; set; }
}
