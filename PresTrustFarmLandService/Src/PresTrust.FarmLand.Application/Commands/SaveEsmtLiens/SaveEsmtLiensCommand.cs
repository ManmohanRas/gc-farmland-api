namespace PresTrust.FarmLand.Application.Commands
{
    public class SaveEsmtLiensCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
    }
}
