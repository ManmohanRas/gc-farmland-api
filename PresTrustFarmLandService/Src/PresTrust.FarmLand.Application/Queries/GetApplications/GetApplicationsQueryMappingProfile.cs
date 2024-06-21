namespace PresTrust.FarmLand.Application.Queries
{
    public class GetApplicationsQueryMappingProfile: Profile
    {
        public GetApplicationsQueryMappingProfile()
        {
            CreateMap<FarmApplicationEntity, GetApplicationsQueryViewModel>();
        }
    }
}
