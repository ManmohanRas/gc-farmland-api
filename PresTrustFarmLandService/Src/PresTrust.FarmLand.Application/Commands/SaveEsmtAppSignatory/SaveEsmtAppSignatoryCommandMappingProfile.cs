namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppSignatoryCommandMappingProfile : Profile
{
    public SaveEsmtAppSignatoryCommandMappingProfile()
    {
        CreateMap<SaveEsmtAppSignatoryCommand, FarmEsmtAppSignatoryEntity>();
    }
}
