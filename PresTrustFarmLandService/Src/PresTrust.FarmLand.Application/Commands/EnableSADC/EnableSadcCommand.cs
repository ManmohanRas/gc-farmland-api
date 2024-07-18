namespace PresTrust.FarmLand.Application.Commands;

public class EnableSadcCommand : IRequest<Unit>
{
    public int ApplicationId { get; set; }
    public bool IsSadc { get; set; }
}
