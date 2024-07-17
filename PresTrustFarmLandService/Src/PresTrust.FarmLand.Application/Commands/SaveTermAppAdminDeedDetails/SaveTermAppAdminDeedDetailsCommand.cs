
namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppAdminDeedDetailsCommand : IRequest<int>
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string OriginalBlock { get; set; }
    public string OriginalLot { get; set; }
    public string OriginalBook { get; set; }
    public string OriginalPage { get; set; }
    public string NOTBook { get; set; }
    public string NOTPage { get; set; }
    public string RDBook { get; set; }
    public string RDPage { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
}


