namespace PresTrust.FarmLand.Application.Commands;

public class EsmtSubmitApplicationCommand : IRequest<EsmtSubmitApplicationCommandViewModel>
{
    public int ApplicationId { get; set; }
}
