namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtExceptionsCommandMappingProfile : Profile
{
    public SaveFarmEsmtExceptionsCommandMappingProfile()
    {
        CreateMap<SaveFarmEsmtExceptionsCommand , FarmEsmtExceptionsEntity> ();
    }
}
