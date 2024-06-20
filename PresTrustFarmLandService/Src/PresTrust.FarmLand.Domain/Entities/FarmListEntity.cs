namespace PresTrust.FarmLand.Domain.Entities
{
    public class FarmListEntity
    {
        public int FarmListId { get; set; }
        public int AgencyId { get; set; }
        public int MunicipalID { get; set; }
        public string Municipality {  get; set; }
        public string AgencyName { get; set; }
        public string FarmNumber { get; set; }
        public string FarmName { get; set; }
        public string OriginalLandowner { get; set; }
        public string OwnerFirst {  get; set; }
        public string OwnerLast {  get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public string Address
        {
            get
            {
                string result = string.Empty;
                result = (this.Street1 ?? string.Empty) + " " + (this.Street2 ?? string.Empty);
                result += " " + (this.City ?? string.Empty) + " " + (this.State ?? string.Empty) + " " + (this.ZipCode ?? string.Empty);
                return result;
            }
        }
    }
}
