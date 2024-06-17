namespace PresTrust.FarmLand.Domain.Entities
{
    public class FarmApplicationEntity
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public string Title { get; set; }
        public int ApplicationTypeId { get; set; }
        public int StatusId { get; set; }
        public bool CreatedByProgramUser { get; set; }
        public bool IsApprovedByMunicipality { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public int MunicipalID { get; set; }
        public string FarmName { get; set; }
        public string Municipality { get; set; }
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

        public ApplicationStatusEnum Status
        {
            get
            {
                return (ApplicationStatusEnum)StatusId;
            }
            set
            {
                this.StatusId = (int)value;
            }
        }

    }
}
