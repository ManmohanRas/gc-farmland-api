namespace PresTrust.FarmLand.Application.Queries;

public class GetAppAdminContactsQueryMappingProfile:Profile
{
    public GetAppAdminContactsQueryMappingProfile()
    {
        CreateMap<TermAppAdminContactsEntity, GetAppAdminContactsQueryViewModel>();
    }
}
