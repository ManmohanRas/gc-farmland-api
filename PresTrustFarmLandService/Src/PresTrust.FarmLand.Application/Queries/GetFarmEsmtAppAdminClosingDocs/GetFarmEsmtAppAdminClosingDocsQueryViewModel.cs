namespace PresTrust.FarmLand.Application.Queries
{
    public class GetFarmEsmtAppAdminClosingDocsQueryViewModel
    {
        public int Id { get; set; }
        public int applicationId { get; set; }
        public string projectStatus { get; set; }
        public int? ePDeedBook { get; set; }
        public int? ePDeedPage { get; set; }
        public DateTime? ePDeedFiled { get; set; }
        public string ePDeedClerkID { get; set; }
        public string countyAttorney { get; set; }
        public string countyAttorneyInfo { get; set; }
        public DateTime? surveyDate { get; set; }
        public string surveyor { get; set; }
        public string titleCompany { get; set; }
        public string titlePolicy { get; set; }
        public DateTime? closingDate { get; set; }
        public string endorsementDates { get; set; }
    }
}
