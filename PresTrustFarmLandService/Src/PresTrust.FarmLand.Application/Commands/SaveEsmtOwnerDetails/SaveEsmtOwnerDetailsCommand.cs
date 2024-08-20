namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtOwnerDetailsCommand : IRequest<int>
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool SoleProprietor { get; set; }
    public bool ProprirtorPartnership { get; set; }
    public bool MultiProprietor { get; set; }
    public bool ExecutorEstate { get; set; }
    public bool CPFeeSimple { get; set; }
    public bool CPEasement { get; set; }
    public bool MunicipalityCurrentEO { get; set; }
    public bool ConservationOrg { get; set; }
    public string FarmName { get; set; }
    public string ResidentName { get; set; }
    public string AttarneyName { get; set; }
    public string AtMailingAddress { get; set; }
    public string ATFirmName { get; set; }
    public string ResiPhoneNumber { get; set; }
    public string PdStreetAddress { get; set; }
    public bool OwnedContinuesly { get; set; }
    public bool SubjectProperty { get; set; }
}
