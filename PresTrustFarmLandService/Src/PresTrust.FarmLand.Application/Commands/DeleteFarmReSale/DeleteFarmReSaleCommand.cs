namespace PresTrust.FarmLand.Application.Commands;

public class DeleteFarmReSaleCommand : IRequest<bool>
{
    public int Id { get; set; }
}
