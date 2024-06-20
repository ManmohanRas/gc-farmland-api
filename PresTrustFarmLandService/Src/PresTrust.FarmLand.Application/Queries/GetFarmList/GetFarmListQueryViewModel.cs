namespace PresTrust.FarmLand.Application.Queries
{
    public class GetFarmListQueryViewModel
    {
        public int AgencyId { get; set; }
        public int FarmListId { get; set; }
        public string AgencyName { get; set; }
        public string FarmNumber { get; set; }
        public string FarmName { get; set; }
        public string OriginalLandowner { get; set; }
        public string OwnerFirst { get; set; }
        public string OwnerLast { get; set; }
    }
}
