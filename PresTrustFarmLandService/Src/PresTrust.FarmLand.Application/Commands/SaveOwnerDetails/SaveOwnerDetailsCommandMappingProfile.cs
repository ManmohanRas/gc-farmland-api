namespace PresTrust.FarmLand.Application.Commands;

public class SaveOwnerDetailsCommandMappingProfile : Profile
{
    public SaveOwnerDetailsCommandMappingProfile()
    {
        CreateMap<SaveOwnerDetailsCommand, OwnerDetailsEntity>();
    }
}
