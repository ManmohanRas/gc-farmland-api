namespace PresTrust.FarmLand.Application.Commands
{
    public class DeleteAttachmentDCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
    }
}
    