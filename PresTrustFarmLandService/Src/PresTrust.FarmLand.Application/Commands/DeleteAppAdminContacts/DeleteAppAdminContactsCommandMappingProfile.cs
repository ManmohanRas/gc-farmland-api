namespace PresTrust.FarmLand.Application.Commands;

public class DeleteAppAdminContactsCommandMappingProfile:Profile
{
    public DeleteAppAdminContactsCommandMappingProfile()
    {
        CreateMap<DeleteTermAppAdminContactsCommand,TermAppAdminContactsEntity>();
    }
}
