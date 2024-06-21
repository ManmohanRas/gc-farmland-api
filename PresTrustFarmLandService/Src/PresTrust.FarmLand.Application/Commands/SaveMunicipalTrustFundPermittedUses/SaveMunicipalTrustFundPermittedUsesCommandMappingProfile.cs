namespace PresTrust.FarmLand.Application.Commands;

public class SaveMunicipalTrustFundPermittedUsesCommandMappingProfile : Profile
{
    public SaveMunicipalTrustFundPermittedUsesCommandMappingProfile()
    {
        CreateMap<SaveMunicipalTrustFundPermittedUsesCommand, FarmMunicipalTrustFundPermittedUsesEntity>();
    }
}
