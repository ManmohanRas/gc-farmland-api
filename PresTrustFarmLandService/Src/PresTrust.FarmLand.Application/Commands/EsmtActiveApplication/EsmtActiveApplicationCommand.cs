namespace PresTrust.FarmLand.Application.Commands;

public class EsmtActiveApplicationCommand : IRequest<EsmtActiveApplicationCommandViewModel>
{
    public int ApplicationId { get; set; }
    public string UserId { get; set; }
}
