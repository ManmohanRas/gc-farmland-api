namespace PresTrust.FarmLand.Domain.Entities;

public class FarmBrokenRuleEntity
{
    public int ApplicationId { get; set; }
    public int SectionId { get; set; }
    public string Message { get; set; }
    public bool IsApplicantFlow { get; set; }

    public TermAppSectionEnum Section
    {
        get
        {
            return (TermAppSectionEnum)SectionId;
        }
        set
        {
            this.SectionId = (int)value;
        }
    }

    public FarmBrokenRuleEntity()
    {
    }

    public FarmBrokenRuleEntity(int applicationId, int sectionId, string message, bool isApplicantFlow)
    {
        this.ApplicationId = applicationId;
        this.SectionId = sectionId;
        this.Message = message;
        this.IsApplicantFlow = isApplicantFlow;
    }
}
