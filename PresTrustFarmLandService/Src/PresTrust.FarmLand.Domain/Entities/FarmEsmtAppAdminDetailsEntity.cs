namespace PresTrust.FarmLand.Domain.Entities;

public class FarmEsmtAppAdminDetailsEntity
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string FarmerName { get; set; }
    public string FarmerPhone { get; set; }
    public string FarmerContactInfo { get; set; }
    public string FarmFeatures { get; set; }
    public bool AgreestoHaveSign { get; set; }
    public string ConsPlanDate { get; set; }
    public string ConsPlanComment { get; set; }
    public string DroppedProjectWhy { get; set; }
    public decimal? ImperviousPercentage { get; set; }
    public decimal? ImperviousSurfaceAcreage { get; set; }
    public bool InterestedinSADCSign { get; set; }
    public bool IsConservationPlan { get; set; }
    public string PossibleClosingDate { get; set; }
    public decimal? PreservedOrder { get; set; }
    public string SADCSignLocation { get; set; }
    public string StaffComments { get; set; }
    public string ZoningJan12004 { get; set; }
    public bool RFPIsAppraisal { get; set; }
    public bool RFPIsSurvey { get; set; }
    public bool RFPIsWetlands { get; set; }
    public int? CADBAppYear { get; set; }
    public int? ProjectYear { get; set; }
    public string OriginalDeed { get; set; }
    public string OriginalPage { get; set; }
    public string SmallOrLargeSign { get; set; }     
    public DateTime? AdYear {get; set;}     
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
}
