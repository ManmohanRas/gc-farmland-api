namespace PresTrust.FarmLand.Application.Commands;
public class SaveTermAppSignatoryCommandMappingProfile : Profile
{
    public SaveTermAppSignatoryCommandMappingProfile()
    {
        CreateMap<SaveTermAppSignatoryCommand, FarmTermAppSignatoryEntity>();
    }
}

