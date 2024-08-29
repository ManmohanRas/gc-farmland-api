namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtApplicationDetailsQueryMappingProfile: Profile
{
    public GetEsmtApplicationDetailsQueryMappingProfile()
    {
        CreateMap<FarmApplicationEntity, GetEsmtApplicationDetailsQueryViewModel>();
    }
}
