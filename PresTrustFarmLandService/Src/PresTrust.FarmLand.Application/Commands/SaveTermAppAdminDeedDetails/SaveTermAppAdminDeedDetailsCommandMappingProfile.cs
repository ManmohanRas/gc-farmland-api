namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppAdminDeedDetailsCommandMappingProfile : Profile
{
    public SaveTermAppAdminDeedDetailsCommandMappingProfile()
    {
        CreateMap<SaveTermAppAdminDeedDetailsCommand, TermAppAdminDeedDetailsEntity>();

    }
}
