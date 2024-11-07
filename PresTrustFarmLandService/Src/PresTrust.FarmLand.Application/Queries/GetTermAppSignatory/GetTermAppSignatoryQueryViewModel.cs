namespace PresTrust.FarmLand.Application.Queries;
public class GetTermAppSignatoryQueryViewModel
{
    public int Id { get; set; } = 0;
    public int ApplicationId { get; set; } = 0;
    public string Municipality { get; set; }
    public string Designation { get; set; } = "";
    public string Title { get; set; } = "";
    public DateTime? SignedOn { get; set; }
}
