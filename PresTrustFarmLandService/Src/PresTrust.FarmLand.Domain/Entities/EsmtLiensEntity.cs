using System.Diagnostics.Metrics;

namespace PresTrust.FarmLand.Domain.Entities
{
    public class EsmtLiensEntity
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public bool PremisePreserved {get; set;}
        public bool BankruptcyJudgment  {get; set;}
        public bool PowerLines   {get; set;}
        public bool WaterLines   {get; set;}
        public bool Sewer    {get; set;}
        public bool Bridge   {get; set;}
        public bool FloodRightWay    {get; set;}
        public bool TelephoneLines   {get; set;}
        public bool GasLines {get; set;}
        public bool Other    {get; set;}
        public bool AccessEasement   {get; set;}
        public string AccessDescribe   {get; set;}
        public bool ConservationEasement {get; set;}
        public string ConservationDescribe {get; set;}
        public bool FederalProgram   {get; set;}
        public string FederalDescribe  {get; set;}
        public bool SolarWindBiomass {get; set;}
        public string BiomassDescribe  {get; set;}
        public DateTime? DateInstallation {get; set;}
        public bool PropertySale {get; set;}
        public bool EstateSituation  {get; set;}
        public bool Bankruptcy { get; set; }
        public bool ForeClosure {get; set;}
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
