namespace PresTrust.FarmLand.Domain.Entities;

public class FarmEsmtAttachmentAEntity
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool IsOfferPriceIndicated { get; set; }
    public string OfferPriceOpinion { get; set; }
    public decimal AveragePerAcre { get; set; }
    public string OfferPriceComments { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }

}
