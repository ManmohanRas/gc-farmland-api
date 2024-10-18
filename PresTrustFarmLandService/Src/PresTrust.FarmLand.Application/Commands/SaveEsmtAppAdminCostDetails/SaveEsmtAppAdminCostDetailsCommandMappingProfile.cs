namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppAdminCostDetailsCommandMappingProfile : Profile
{
    public SaveEsmtAppAdminCostDetailsCommandMappingProfile()
    {
        CreateMap<SaveEsmtAppAdminCostDetailsCommand, FarmEsmtAppAdminCostDetailsEntity>();
    }
}
