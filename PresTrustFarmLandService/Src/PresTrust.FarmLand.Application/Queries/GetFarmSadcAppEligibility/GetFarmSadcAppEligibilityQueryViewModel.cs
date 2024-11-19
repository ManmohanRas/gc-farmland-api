namespace PresTrust.FarmLand.Application.Queries
{
    public class GetFarmSadcAppEligibilityQueryViewModel
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string ProjectAreaAppEl { get; set; }
        public decimal? RankScore { get; set; }
        public decimal? RankPoints { get; set; }
        public decimal? SoilPercentage { get; set; }
        public bool IsLandsLessThan10Ac { get; set; }
        public bool IsLandsGreaterThan10Ac { get; set; }
        public bool Is75PercentTillable { get; set; }
        public decimal? Percent75Tillable1 { get; set; }
        public decimal? Acre75Tillable { get; set; }
        public bool Is75PercentLand { get; set; }
        public decimal? Percent75Land { get; set; }
        public decimal? Acre75Land { get; set; }
        public bool Is50PercentTillable { get; set; }
        public decimal? Percent50Tillable { get; set; }
        public decimal? Acre50Tillable { get; set; }
        public bool Is50PercentLand { get; set; }
        public decimal? Percent50Land { get; set; }
        public decimal? Acre50Land { get; set; }
    }
}
