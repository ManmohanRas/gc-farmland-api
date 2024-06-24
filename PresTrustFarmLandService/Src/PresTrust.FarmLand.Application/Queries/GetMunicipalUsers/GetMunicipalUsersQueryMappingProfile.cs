using PresTrust.FarmLand.Application.Services.IdentityApi;

namespace PresTrust.FarmLand.Application.Queries;

public class GetMunicipalUsersQueryMappingProfile : Profile
{
    public GetMunicipalUsersQueryMappingProfile()
    {
        CreateMap<IdentityApiUser, PresTrustUserEntity>()
        .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.UserRole));
    }
}
