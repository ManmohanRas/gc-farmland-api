namespace PresTrust.FarmLand.Application.Commands;

public class EsmtInReviewApplicationCommand : IRequest<EsmtInReviewApplicationCommandViewModel>
{
    public int ApplicationId { get; set; }
    public string UserId { get; set; }
}
