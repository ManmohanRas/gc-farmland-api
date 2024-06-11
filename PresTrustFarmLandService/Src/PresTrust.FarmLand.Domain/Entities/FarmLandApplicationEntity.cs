namespace PresTrust.FarmLand.Domain.Entities
{
    public class FarmLandApplicationEntity
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public string Title { get; set; }
        public int ApplicationTypeId { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public bool CreatedByProgramAdmin { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public bool IsActive { get; set; }


        public ApplicationTypeEnum ApplicationType
        {
            get
            {
                return (ApplicationTypeEnum)ApplicationTypeId;
            }
            set
            {
                this.ApplicationTypeId = (int)value;
            }
        }

    }
}
