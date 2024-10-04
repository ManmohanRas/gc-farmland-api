namespace PresTrust.FarmLand.Application.Queries;

public class GetTermAppAdminDeedDetailsQueryViewModel
{

    public int ApplicationId { get; set; }
    public List<DocumentTypeViewModel> DocumentsTree { get; set; } = new List<DocumentTypeViewModel>();
    public IEnumerable<TermAppAdminDeedDetailsViewModel> DeedDetails { get; set; }
}
public class TermAppAdminDeedDetailsViewModel
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public int ParcelId { get; set; }
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
    public bool IsChecked { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
}


