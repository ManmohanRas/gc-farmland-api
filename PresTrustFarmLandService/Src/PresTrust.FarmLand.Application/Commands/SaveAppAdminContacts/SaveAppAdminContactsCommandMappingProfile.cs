namespace PresTrust.FarmLand.Application.Commands;

public  class SaveAppAdminContactsCommandMappingProfile:Profile
{
    public SaveAppAdminContactsCommandMappingProfile()
    {
        CreateMap<SaveContactsModel, TermAppAdminContactsEntity>();

    }
}
