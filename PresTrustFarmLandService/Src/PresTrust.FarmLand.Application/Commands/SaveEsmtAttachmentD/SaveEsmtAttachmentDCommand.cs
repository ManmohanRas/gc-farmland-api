namespace PresTrust.FarmLand.Application.Commands
 {
    public class SaveEsmtAttachmentDCommand : IRequest<Unit>
    {
        public int ApplicationId { get; set; }
        public string UserId { get; set; }
        public IEnumerable<SaveEsmtAttachmentDViewModel> AttachmentDetails { get; set; }

    }
        public class SaveEsmtAttachmentDViewModel
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
