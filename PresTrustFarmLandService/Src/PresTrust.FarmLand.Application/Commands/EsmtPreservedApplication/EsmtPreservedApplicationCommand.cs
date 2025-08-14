namespace PresTrust.FarmLand.Application.Commands;

public class EsmtPreservedApplicationCommand : IRequest<EsmtPreservedApplicationCommandViewModel>
{
    public int ApplicationId { get; set; }
    public string UserId { get; set; }
}
