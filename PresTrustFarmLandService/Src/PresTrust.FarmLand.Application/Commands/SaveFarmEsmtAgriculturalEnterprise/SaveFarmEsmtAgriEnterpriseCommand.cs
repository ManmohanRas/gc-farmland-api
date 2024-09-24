namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtAgriEnterpriseCommand : IRequest<int>
{
    public int ApplicationId { get; set; }
    public int Id { get; set; }
    public string AverageGrossReceipts { get; set; }
    public bool IsFullTimeFarmer { get; set; }
    public bool HasSoilConservationPlan { get; set; }
    public DateTime? PlanDate { get; set; }
    public string ConservationPractices { get; set; }
    public string AgriculturalInvestments { get; set; }
    public IEnumerable<SaveFarmEsmtAgriCheckListViewModel> AgriCheckList { get; set; }

}

public class SaveFarmEsmtAgriCheckListViewModel
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public int ActivitySubTypeId { get; set; }
    public string Title  { get; set; }
    public string SicCode { get; set; }
    public bool IsPrimary { get; set; }
    public bool IsSecondary { get; set; }
}
