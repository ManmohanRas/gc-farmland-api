namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppAdminDeedDetailsCommandMappingProfile : Profile
{
    public SaveTermAppAdminDeedDetailsCommandMappingProfile()
    {
        CreateMap<SaveTermAppAdminDeedListCommand, TermAppAdminDeedDetailsEntity>();

    }
}
