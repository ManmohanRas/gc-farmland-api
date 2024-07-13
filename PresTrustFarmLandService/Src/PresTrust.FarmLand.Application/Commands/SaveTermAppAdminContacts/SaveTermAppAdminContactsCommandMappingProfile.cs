

namespace PresTrust.FarmLand.Application.Commands;

public  class SaveTermAppAdminContactsCommandMappingProfile:Profile
{
    public SaveTermAppAdminContactsCommandMappingProfile()
    {
        CreateMap<SaveContactsModel, TermAppAdminContactsEntity>();

    }
}
