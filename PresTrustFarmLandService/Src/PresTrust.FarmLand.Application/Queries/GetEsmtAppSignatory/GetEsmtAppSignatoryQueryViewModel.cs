namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppSignatoryQueryViewModel
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public decimal? AmountPerAcre { get; set; }
    public string Designation { get; set; } 
    public string Title { get; set; } 
    public DateTime? SignedOn { get; set; }
    public string LastUpdatedBy {  get; set; }
    public DateTime? LastUpdatedOn { get; set; }

    public IEnumerable<FarmEsmtAttachmentAViewModel>? AttachmentAs { get; set; }
}

public class FarmEsmtAttachmentAViewModel
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool IsOfferPriceIndicated { get; set; }
    public string OfferPriceOpinion { get; set; }
    public int AveragePerAcre { get; set; }
    public string OfferPriceComments { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }

}
