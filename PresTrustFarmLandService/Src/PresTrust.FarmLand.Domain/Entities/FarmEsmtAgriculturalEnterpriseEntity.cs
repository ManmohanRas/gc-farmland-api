namespace PresTrust.FarmLand.Domain.Entities;

public class FarmEsmtAgriculturalEnterpriseEntity
{
        public int Id { get; set; }
        public  int ApplicationId { get; set; }
        public string AverageGrossReceipts { get; set; }
        public bool IsFullTimeFarmer { get; set; }
        public bool HasSoilConservationPlan { get; set; }
        public DateTime? PlanDate { get; set; }
        public string ConservationPractices { get; set; }
        public string AgriculturalInvestments { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
}
