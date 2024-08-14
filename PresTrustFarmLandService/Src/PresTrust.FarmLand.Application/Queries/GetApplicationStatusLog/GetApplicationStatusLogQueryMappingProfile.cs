namespace PresTrust.FarmLand.Application.Queries;

public class GetApplicationStatusLogQueryMappingProfile : Profile
{

    public GetApplicationStatusLogQueryMappingProfile()
    {
        CreateMap<FarmApplicationStatusLogEntity, GetApplicationStatusLogQueryViewModel>();
    }
}
