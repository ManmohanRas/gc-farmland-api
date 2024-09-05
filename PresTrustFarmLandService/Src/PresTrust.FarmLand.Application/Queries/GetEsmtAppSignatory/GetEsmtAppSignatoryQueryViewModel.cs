namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppSignatoryQueryViewModel
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public decimal? AmountPerAcre { get; set; }
    public string Designation { get; set; } 
    public string Title { get; set; } 
    public DateTime? SignedOn { get; set; }
}
