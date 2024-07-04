namespace PresTrust.FarmLand.Application.Commands;
public class SaveApplicationSignatoryCommandMappingProfile : Profile
{
    public SaveApplicationSignatoryCommandMappingProfile()
    {
        CreateMap<SaveApplicationSignatoryCommand, FarmApplicationSignatoryEntity>();
    }
}

