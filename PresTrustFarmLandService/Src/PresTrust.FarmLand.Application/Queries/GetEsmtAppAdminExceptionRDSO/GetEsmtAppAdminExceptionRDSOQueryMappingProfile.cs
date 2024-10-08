namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppAdminExceptionRDSOQueryMappingProfile : Profile
{
    public GetEsmtAppAdminExceptionRDSOQueryMappingProfile()
    {
        CreateMap<EsmtAppAdminExceptionRDSOEntity, GetEsmtAppAdminExceptionRDSOQueryViewModel>();
    }
}
