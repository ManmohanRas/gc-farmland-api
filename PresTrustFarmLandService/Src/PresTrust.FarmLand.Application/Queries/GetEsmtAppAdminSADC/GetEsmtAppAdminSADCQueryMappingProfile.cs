namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppAdminSADCQueryMappingProfile : Profile
{
    public GetEsmtAppAdminSADCQueryMappingProfile()
    {
        CreateMap<EsmtAppAdminSADCEntity, GetEsmtAppAdminSADCQueryViewModel>();
    }
}
