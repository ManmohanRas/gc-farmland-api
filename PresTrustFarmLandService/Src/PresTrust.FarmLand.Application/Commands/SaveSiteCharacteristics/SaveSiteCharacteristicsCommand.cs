

namespace PresTrust.FarmLand.Application.Commands;

public class SaveSiteCharacteristicsCommand:IRequest<int>
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string Area { get; set; }
    public string LandUse { get; set; }
    public string Cropland { get; set; }
    public string Woodland { get; set; }
    public string Pasture { get; set; }
    public string Orchard { get; set; }

    public string Other { get; set; }
    public string EasementOrRightOfway { get; set; }
    public string NoteEasementOrRightOfway { get; set; }
    public string MortgageLiens { get; set; }
    public string NoteMortgageLiens { get; set; }

}
