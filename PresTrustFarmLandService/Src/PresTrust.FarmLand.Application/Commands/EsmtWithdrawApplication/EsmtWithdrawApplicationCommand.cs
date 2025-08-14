namespace PresTrust.FarmLand.Application.Commands;

/// <summary>
/// This class represents api's query input model and returns the response object
/// </summary>
public class EsmtWithdrawApplicationCommand : IRequest<Unit>
{
    public int ApplicationId { get; set; }
    public string UserId { get; set; }
}
