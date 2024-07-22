namespace PresTrust.FarmLand.Domain.Entities;

public class TermCommentsEntity
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string Comment { get; set; }
    public int CommentTypeId { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
}
