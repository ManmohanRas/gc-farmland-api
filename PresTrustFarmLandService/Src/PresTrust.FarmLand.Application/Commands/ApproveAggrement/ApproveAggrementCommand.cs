namespace PresTrust.FarmLand.Application.Commands;

public class ApproveAggrementCommand : IRequest<ApproveAggrementCommandViewmodel>
{
    public int ApplicationId { get; set; }
}