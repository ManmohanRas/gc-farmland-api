namespace PresTrust.FarmLand.Application.Queries;

public class GetApplicationDetailsQueryMappingProfile: Profile
{
    public GetApplicationDetailsQueryMappingProfile()
    {
        CreateMap<FarmApplicationEntity, GetApplicationDetailsQueryViewModel>();
    }
}
