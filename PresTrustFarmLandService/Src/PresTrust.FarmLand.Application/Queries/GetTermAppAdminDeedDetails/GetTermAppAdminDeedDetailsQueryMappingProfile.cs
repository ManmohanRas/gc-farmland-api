namespace PresTrust.FarmLand.Application.Queries;

public class GetTermAppAdminDeedDetailsQueryMappingProfile : Profile
{
    public GetTermAppAdminDeedDetailsQueryMappingProfile()
    {
        CreateMap<TermAppAdminDeedDetailsEntity, TermAppAdminDeedDetailsViewModel>();
    }
}
