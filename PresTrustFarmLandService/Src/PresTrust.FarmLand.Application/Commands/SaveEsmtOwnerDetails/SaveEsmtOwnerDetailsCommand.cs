namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtOwnerDetailsCommand : IRequest<int>
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool SoleProprietor { get; set; }
    public bool ContractPurchaser { get; set; }
    public bool PartnerofPartnership { get; set; }
    public bool ContractPurchaserEasement { get; set; }
    public bool MultiProprietor { get; set; }
    public bool Municipality { get; set; }
    public bool ExecutorofanEstate { get; set; }
    public bool ConservationOrganization { get; set; }
    public bool CorporateOfficer { get; set; }
    public bool Institution { get; set; }
    public bool TrusteeofaTrust { get; set; }
    public string FarmName { get; set; }
    public string ResidentName { get; set; }
    public string ResidentPhoneNumber { get; set; }
    public string ListOfAddress { get; set; }
    public string Name { get; set; }
    public string FirmName { get; set; }
    public string MailingAddress { get; set; }
    public bool OwnedContinuesly { get; set; }
    public bool SubjectProperty { get; set; }
}
