
namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtExceptionsCommand: IRequest<int>
{

    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool ExpectedTaxLots { get; set; }
    public string ExceptionNonServable { get; set; }
    public string ExceptionTotalNonServable { get; set; }
    public string ExceptionServable { get; set; }
    public string ExceptionTotalServable { get; set; }
    public decimal Acres { get; set; }
}
