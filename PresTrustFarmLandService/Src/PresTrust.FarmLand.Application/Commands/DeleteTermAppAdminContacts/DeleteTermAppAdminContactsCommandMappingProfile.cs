
namespace PresTrust.FarmLand.Application.Commands;

public class DeleteTermAppAdminContactsCommandMappingProfile:Profile
{
    public DeleteTermAppAdminContactsCommandMappingProfile()
    {
        CreateMap<DeleteTermAppAdminContactsCommand,TermAppAdminContactsEntity>();
    }
}
