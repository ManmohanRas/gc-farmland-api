namespace PresTrust.FarmLand.Application.Commands;

public class ResolveParcelWarningCommand: IRequest<bool>
{
    public int ParcelId { get; set; }
}
