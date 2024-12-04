namespace PresTrust.FarmLand.Domain.Entities;

public class FarmReSaleEntity
{
    public int Id { get; set; }
    public string FarmNumber { get; set; }
    public DateTime? ReSellDate { get; set; }
    public decimal? ReSellPriceTotal { get; set; }
    public decimal? ReSellPricePerAcre { get; set; }
    public string ReSellNotes { get; set; }
    public string CurrentDeedBook { get; set; }
    public string CurrentDeedPage { get; set; }
    public DateTime? CurrentDeedFiled { get; set; }
    public bool InterestedinSelling { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }
}
