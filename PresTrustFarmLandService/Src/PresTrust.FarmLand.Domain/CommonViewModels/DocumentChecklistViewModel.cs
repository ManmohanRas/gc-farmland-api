namespace PresTrust.FarmLand.Domain.CommonViewModels;

public class DocumentChecklistViewModel
{
    public string Section { get; set; }
    public List<DocumentChecklistDocTypeViewModel> DocumentChecklistDocTypeItems { get; set; }
}
