namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmMonitoringQueryMappingProfile : Profile
{
    public GetFarmMonitoringQueryMappingProfile()
    {
        CreateMap<FarmMonitoringEntity, GetFarmMonitoringQueryViewModel>();
    }
}
