namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmSadcResidenceCommand : IRequest<int>
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool IsAgriculturalLabor { get; set; }
    public string UnitsUsedForLabor { get; set; }
    public int? Occupants { get; set; }
    public int? MonthsOccupied { get; set; }
    public bool IsOccupantsWork { get; set; }
    public string PleaseExplain { get; set; }
    public bool IsResidencesRented { get; set; }
    public string RDSOsReserve { get; set; }
    public decimal? ExcepAcres1 { get; set; }
    public bool NonSeverable1 { get; set; }
    public bool Severable1 { get; set; }
    public string AdditionalComment1 { get; set; }
    public decimal? ExcepAcres2 { get; set; }
    public bool NonSeverable2 { get; set; }
    public bool Severable2 { get; set; }
    public string AdditionalComment2 { get; set; }
    public string EsmtOthersText { get; set; }
    public bool IsSightTriangle { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public string UserId { get; set; }
}
