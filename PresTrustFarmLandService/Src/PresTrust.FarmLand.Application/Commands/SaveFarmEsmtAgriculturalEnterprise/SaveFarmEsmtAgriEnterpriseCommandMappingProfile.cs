namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtAgriEnterpriseCommandMappingProfile : Profile
{
    public SaveFarmEsmtAgriEnterpriseCommandMappingProfile()
    {
        CreateMap<SaveFarmEsmtAgriEnterpriseCommand, FarmEsmtAgriculturalEnterpriseEntity>();
        CreateMap<SaveFarmEsmtAgriCheckListViewModel, FarmAgriculturalEnterpriseChecklistEntity>();
    }
}
