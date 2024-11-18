namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtSadcHistoryCommand : IRequest<int>
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public decimal? SquareFootage { get; set; }
    public DateTime PreliminaryExpiration { get; set; }
    public DateTime FinalExpiration { get; set; }
    public bool EstateWill { get; set; }
    public bool TaxWaiver { get; set; }
    public bool NoWaiver { get; set; }
    public bool TrustWill { get; set; }
    public bool TrustDocuments { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
}
