

namespace PresTrust.FarmLand.Application.Queries;

public class GetTermAppAdminContactsQueryMappingProfile:Profile
{
    public GetTermAppAdminContactsQueryMappingProfile()
    {
        CreateMap<TermAppAdminContactsEntity, GetTermAppAdminContactsQueryViewModel>();
    }
}
