namespace PresTrust.FarmLand.Domain.Entities;

public class TermOtherDocumentsEntity
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public int ApplicationTypeId { get; set; }
    public int DocumentTypeId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string FileName { get; set; }
    public bool UseInReport { get; set; }
    public bool HardCopy { get; set; }
    public bool Approved { get; set; }
    public string ReviewComment { get; set; }
    public int SectionId { get; set; }
    public bool ShowCommitte { get; set; }
  //  public int? OtherFundingSourceId { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public ApplicationDocumentTypeEnum DocumentType
    {
        get
        {
            return (ApplicationDocumentTypeEnum)DocumentTypeId;
        }
        set
        {
            this.DocumentTypeId = (int)value;
        }
    }

    public dynamic Section
    {
        get
        {
            if (this.SectionId > 199)
            {
                return (EsmtAppSectionEnum)SectionId;
            }
            else
                return (TermAppSectionEnum)SectionId;
        }
        set
        {
            this.SectionId = (int)value;
        }
    }
    public EsmtAppSectionEnum EsmtSection
    {
        get
        {
            return (EsmtAppSectionEnum)SectionId;
        }
        set 
        {
            this.SectionId = (int)value;
        }
    }
}
