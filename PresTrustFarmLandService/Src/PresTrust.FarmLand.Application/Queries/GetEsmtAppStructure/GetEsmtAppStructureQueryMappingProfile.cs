

namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppStructureQueryMappingProfile:Profile
{
    public GetEsmtAppStructureQueryMappingProfile()
    {
        CreateMap<EsmtStructureAppEntity,GetEsmtAppStructureQueryViewModel>();
    }
}
