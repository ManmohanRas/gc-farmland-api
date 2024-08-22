namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtOwnerDetailsCommandMappingProfile : Profile
{
    public SaveEsmtOwnerDetailsCommandMappingProfile()
    {
        CreateMap<SaveEsmtOwnerDetailsCommand, EsmtOwnerDetailsEntity>();
    }
}
