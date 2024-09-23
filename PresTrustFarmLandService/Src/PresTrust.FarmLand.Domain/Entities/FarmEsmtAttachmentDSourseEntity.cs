namespace PresTrust.FarmLand.Domain.Entities
{
    public class FarmEsmtAttachmentDSourseEntity
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int EquineActivityTypeId { get; set; }
        public string Title { get; set; }
        public decimal Counts { get; set; }
        public int Number { get; set; }
        public int NumberOfHorses { get; set;}              
        public int NumberOfHorsesActivity  { get; set;}              
        public int NumberOfStalls { get; set;}              
        public int RunInSheds { get; set;}              
        public int IndoorRidingArena { get; set;}              
        public int OutdoorRidingArena { get; set; }              
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
