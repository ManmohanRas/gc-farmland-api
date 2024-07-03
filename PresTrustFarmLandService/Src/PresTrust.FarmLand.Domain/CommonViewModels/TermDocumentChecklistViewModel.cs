namespace PresTrust.FarmLand.Domain.CommonViewModels;

public class TermDocumentChecklistViewModel
{
    public string Section { get; set; }
    public List<TermDocumentChecklistDocTypeViewModel> DocumentChecklistDocTypeItems { get; set; }
}
