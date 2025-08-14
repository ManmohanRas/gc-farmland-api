namespace PresTrust.FarmLand.Application.Commands;

public class EsmtClosingApplicationCommand : IRequest<EsmtClosingApplicationCommandViewModel>
{
    public int ApplicationId { get; set; }
    public string UserId { get; set; }
}