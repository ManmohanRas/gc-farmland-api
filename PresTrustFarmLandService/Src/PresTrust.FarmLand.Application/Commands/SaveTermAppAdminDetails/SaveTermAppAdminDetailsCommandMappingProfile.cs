
namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppAdminDetailsCommandMappingProfile : Profile
{
    public SaveTermAppAdminDetailsCommandMappingProfile()
    {
        CreateMap<SaveTermAppAdminDetailsCommand, FarmTermAppAdminDetailsEntity>();
    }
}
