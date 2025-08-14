
namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtExceptionsCommand: IRequest<int>
{

    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool ExpectedTaxLots { get; set; }
    public string ExceptionNonSeverable { get; set; }
    public string ExceptionTotalNonSeverable { get; set; }
    public string ExceptionSeverable { get; set; }
    public string ExceptionTotalSeverable { get; set; }
    public decimal? Acres { get; set; }
    public string UserId { get; set; }
}
