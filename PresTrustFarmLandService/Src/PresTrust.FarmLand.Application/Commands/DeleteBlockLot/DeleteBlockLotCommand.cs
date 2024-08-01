namespace PresTrust.FarmLand.Application.Commands;

public class DeleteBlockLotCommand: IRequest<bool>
{
    public int Id {  get; set; }
}
