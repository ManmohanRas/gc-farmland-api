namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtAppAdminStructNonAgWetlandsCommandMappingProfile : Profile
{
    public SaveFarmEsmtAppAdminStructNonAgWetlandsCommandMappingProfile()
    {
        CreateMap<SaveFarmEsmtAppAdminStructNonAgWetlandsCommand, FarmEsmtAppAdminStructNonAgWetlandsEntity>();
    }
}
