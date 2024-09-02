namespace PresTrust.FarmLand.Domain.CommonViewModels
{
    public class DocumentChecklistDocTypeViewModel
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string Section { get; set; }
        public string DocumentType { get; set; }
        public List<DocumentsViewModel> Documents { get; set; }
    }
}
