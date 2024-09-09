
namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppAdminDeedDetailsCommand : IRequest<Unit>
{
    public int ApplicationId { get; set; }
    public List<SaveTermAppAdminDeedListCommand> DeedDetails { get; set; } = new List<SaveTermAppAdminDeedListCommand>();
}

public class SaveTermAppAdminDeedListCommand
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string OriginalBlock { get; set; }
    public string OriginalLot { get; set; }
    public string OriginalBook { get; set; }
    public string OriginalPage { get; set; }
    public string NOTBlock { get; set; }
    public string NOTLot { get; set; }
    public string NOTBook { get; set; }
    public string NOTPage { get; set; }
    public string RDBlock { get; set; }
    public string RDLot { get; set; }
    public string RDBook { get; set; }
    public string RDPage { get; set; }
    public string RowStatus { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
}


