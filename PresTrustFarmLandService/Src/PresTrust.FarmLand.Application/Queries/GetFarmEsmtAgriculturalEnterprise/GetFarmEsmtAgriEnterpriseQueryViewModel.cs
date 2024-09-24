namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtAgriEnterpriseQueryViewModel
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string AverageGrossReceipts { get; set; }
    public bool IsFullTimeFarmer { get; set; }
    public bool HasSoilConservationPlan { get; set; }
    public DateTime? PlanDate { get; set; }
    public string ConservationPractices { get; set; }
    public string AgriculturalInvestments { get; set; }
    public IEnumerable<FarmEsmtAgriCheckListViewModel> AgriCheckList { get; set; }

}

public class FarmEsmtAgriCheckListViewModel
{
    public int Id { get; set; }
    public int ActivitySubTypeId { get; set; }
    public string Title { get; set; }
    public string SicCode { get; set; }
    public int ActivityTypeId { get; set; }
    public bool IsPrimary { get; set; }
    public bool IsSecondary { get; set; }
}
