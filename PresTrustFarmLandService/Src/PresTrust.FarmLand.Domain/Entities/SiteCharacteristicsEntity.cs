
namespace PresTrust.FarmLand.Domain.Entities;

public class SiteCharacteristicsEntity
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string Area { get; set; }
    public string LandUse { get; set; }
    public decimal CropLand { get; set; }
    public decimal WoodLand { get; set; }
    public decimal Pasture { get; set; }
    public decimal Orchard { get; set; }
    public decimal Other { get; set; }
    public string EasementRightOfway { get; set; }
    public string NoteEasementRightOfway { get; set; }
    public string MortgageLiens { get; set; }
    public string NoteMortgageLiens { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }
}
