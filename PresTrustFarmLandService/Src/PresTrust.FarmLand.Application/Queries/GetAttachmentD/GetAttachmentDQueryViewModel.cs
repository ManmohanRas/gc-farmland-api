namespace PresTrust.FarmLand.Application.Queries
{
    public class GetAttachmentDQueryViewModel
    {
        public int ApplicationId { get; set; }
        public IEnumerable<EsmtAttachmentDViewModel> AttachmentDetails { get; set; }
    }

    public class EsmtAttachmentDViewModel
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int EquineActivityTypeId { get; set; }
        public decimal Counts { get; set; }
        public int Number { get; set; }
        public int NumberOfHorses { get; set; }
        public int NumberOfHorsesActivity { get; set; }
        public int NumberOfStalls { get; set; }
        public int RunInSheds { get; set; }
        public int IndoorRidingArena { get; set; }
        public int OutdoorRidingArena { get; set; }
    }
}
