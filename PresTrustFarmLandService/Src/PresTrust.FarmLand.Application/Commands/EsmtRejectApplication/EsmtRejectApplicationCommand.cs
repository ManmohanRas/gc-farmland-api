
namespace PresTrust.FarmLand.Application.Commands;
public class EsmtRejectApplicationCommand:IRequest<Unit>
{
    public int ApplicationId { get; set; }
}
