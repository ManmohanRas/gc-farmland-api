namespace PresTrust.FarmLand.Application.Queries
{
    public class GetApplicationsQueryViewModel
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public int FarmListId {  get; set; }
        public string Title { get; set; }
        public string ApplicationType { get; set; }
        public int ApplicationTypeId { get; set; }
        public string Status { get; set; }
        public bool CreatedByProgramUser { get; set; }
        public bool IsApprovedByMunicipality { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int MunicipalID { get; set; }
        public string FarmName { get; set; }
        public string Municipality { get; set; }
        public string OriginalLandowner { get; set; }

    }
}
