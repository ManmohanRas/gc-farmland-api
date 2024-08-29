namespace PresTrust.FarmLand.Application.Queries;

public class GetTermApplicationDetailsQueryMappingProfile: Profile
{
    public GetTermApplicationDetailsQueryMappingProfile()
    {
        CreateMap<FarmApplicationEntity, GetTermApplicationDetailsQueryViewModel>();
    }
}
