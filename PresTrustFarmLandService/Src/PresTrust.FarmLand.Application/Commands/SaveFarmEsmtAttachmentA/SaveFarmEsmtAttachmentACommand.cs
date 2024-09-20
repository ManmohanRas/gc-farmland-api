namespace PresTrust.FarmLand.Application.Commands.SaveFarmEsmtAttachmentA;

public class SaveFarmEsmtAttachmentACommand : IRequest<int>
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool IsOfferPriceIndicated { get; set; }
    public bool OfferPriceOpinion { get; set; }
    public int AveragePerAcre { get; set; }
    public string OfferPriceComments { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }

}
