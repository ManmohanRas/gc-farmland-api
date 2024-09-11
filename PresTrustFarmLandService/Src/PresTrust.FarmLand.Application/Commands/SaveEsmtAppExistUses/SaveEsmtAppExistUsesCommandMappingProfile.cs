namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppExistUsesCommandMappingProfile:Profile
{
    public SaveEsmtAppExistUsesCommandMappingProfile()
    {
        CreateMap<SaveEsmtAppExistUsesCommand, EsmtAppExistUsesEntity>();


    }
}
