namespace PresTrust.FarmLand.Domain.Entities;
public class FarmEsmtAppAdminStructNonAgWetlandsEntity
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool IsResidenceOnPresLand { get; set; }
    public string ImprovRes { get; set; }
    public bool AreNonAgUses { get; set; }
    public string NonAgExplan { get; set; }
    public bool IsFarmMarket { get; set; }
    public string ImprovAg { get; set; }
    public string WetlandsSurveyor { get; set; }
    public DateTime? DateofDelineation { get; set; }
    public decimal AcresofWetlands { get; set; }
    public decimal AcresofTransitionArea { get; set; }
    public string WetlandsClassification { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
}
