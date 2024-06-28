namespace PresTrust.FarmLand.Domain.Entities;

public class OwnerDetailsEntity
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PropertyLocation { get; set; }
    public string Municipality { get; set; }
    public string MailingAddress1 { get; set; }
    public string MailingAddress2 { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int ZipCode { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }
}
