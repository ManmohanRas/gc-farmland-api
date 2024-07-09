using PresTrust.FarmLand.Application.Queries;

namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppAdminDetailsCommandMappingProfile : Profile
{
    public SaveTermAppAdminDetailsCommandMappingProfile()
    {
        CreateMap<FarmTermAppAdminDetailsEntity, SaveTermAppAdminDetailsCommandMappingProfile>();
    }
}
