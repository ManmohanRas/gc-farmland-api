namespace PresTrust.FarmLand.Domain.Entities;

public class FarmEmailTemplateEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string TemplateCode { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public string LastUpdatedBy { get; set; }
    public string LastUpdatdOn { get; set; }
}
