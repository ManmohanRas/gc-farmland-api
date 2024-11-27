namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmSadcResidenceQueryMappingProfile : Profile
{
    public GetFarmSadcResidenceQueryMappingProfile()
    {
        CreateMap<FarmSadcResidenceEntity, GetFarmSadcResidenceQueryViewModel>();
    }
}
