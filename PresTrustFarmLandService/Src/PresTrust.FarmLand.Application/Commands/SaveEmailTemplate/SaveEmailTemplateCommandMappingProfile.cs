namespace PresTrust.FarmLand.Application.Commands;

public class SaveEmailTemplateCommandMappingProfile: Profile
{
    public SaveEmailTemplateCommandMappingProfile()
    {
        CreateMap<SaveEmailTemplateCommand, FarmEmailTemplateEntity>();
    }
}
