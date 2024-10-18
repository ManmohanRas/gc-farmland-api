namespace PresTrust.FarmLand.Domain.Entities
{
    public class FarmEsmtAppAdminClosingDocsEntity
    {

        public int Id { get; set; }						
        public int ApplicationId { get; set; }				
        public string ProjectStatus { get; set; }				
        public int? EPDeedBook { get; set; }					
        public int? EPDeedPage { get; set; }					
        public DateTime? EPDeedFiled { get; set; }					
        public string EPDeedClerkID { get; set; }					
        public string CountyAttorney { get; set; }				
        public string CountyAttorneyInfo { get; set; }			
        public DateTime? SurveyDate { get; set; }				
        public string Surveyor { get; set; }				
        public string TitleCompany { get; set; }
        public string TitlePolicy { get; set; }
        public DateTime? ClosingDate { get; set; }
        public string EndorsementDates { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
