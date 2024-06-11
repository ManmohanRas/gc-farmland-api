namespace PresTrust.FarmLand.Application.Commands.CreateApplication
{
    public class CreateApplicationCommand: IRequest<CreateApplicationCommandViewModel>
    {
        public string Title { get; set; } = "";
        public int AgencyId { get; set; }
        public string ApplicationType { get; set; }
    }
}
