namespace PresTrust.FarmLand.Domain.CommonViewModels
{
    public class TermDocumentChecklistDocTypeViewModel
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string Section { get; set; }
        public string DocumentType { get; set; }
        public List<TermDocumentsViewModel> Documents { get; set; }
    }
}
