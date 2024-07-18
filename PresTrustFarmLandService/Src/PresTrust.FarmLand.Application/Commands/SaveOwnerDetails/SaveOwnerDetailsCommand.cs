using PresTrust.FarmLand.Application.Queries;

namespace PresTrust.FarmLand.Application.Commands;

public class SaveOwnerDetailsCommand : IRequest<int>
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PropertyLocation { get; set; }
    public int MunicipalityId { get; set; }
    public string MailingAddress1 { get; set; }
    public string MailingAddress2 { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
}
