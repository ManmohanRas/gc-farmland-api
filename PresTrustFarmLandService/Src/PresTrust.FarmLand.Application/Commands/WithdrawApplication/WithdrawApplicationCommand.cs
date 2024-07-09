namespace PresTrust.FarmLand.Application.Commands;

/// <summary>
/// This class represents api's query input model and returns the response object
/// </summary>
public class WithdrawApplicationCommand : IRequest<Unit>
{
    public int ApplicationId { get; set; }
}
