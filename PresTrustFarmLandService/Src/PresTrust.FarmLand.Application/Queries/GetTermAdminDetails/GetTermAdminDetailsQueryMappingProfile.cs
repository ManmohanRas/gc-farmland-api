namespace PresTrust.FarmLand.Application.Queries;

public class GetTermAdminDetailsQueryMappingProfile : Profile
{
    public GetTermAdminDetailsQueryMappingProfile() 
    {
     CreateMap<FarmTermAppAdminDetailsEntity, GetTermAdminDetailsQueryViewModel> ();
    }
}
