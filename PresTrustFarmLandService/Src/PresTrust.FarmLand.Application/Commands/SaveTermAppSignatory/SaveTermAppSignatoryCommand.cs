namespace PresTrust.FarmLand.Application.Commands;
public class SaveTermAppSignatoryCommand : IRequest<int>
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string? Designation { get; set; }
    public string Municipality { get; set; }
    public string? Title { get; set; }
    public DateTime? SignedOn { get; set; }
}

