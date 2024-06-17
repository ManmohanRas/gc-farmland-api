using PresTrust.FarmLand.Application.Services.IdentityApi;

namespace PresTrust.FarmLand.Application.Queries;

public class GetRolesQueryMappingProfile : Profile
{
    public GetRolesQueryMappingProfile()
    {
        CreateMap<IdentityApiUser, FarmRolesViewModel>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.UserRole));

        CreateMap<FarmRolesEntity, FarmRolesViewModel>();
        CreateMap<FarmRolesViewModel, FarmRolesEntity>();
    }
}
