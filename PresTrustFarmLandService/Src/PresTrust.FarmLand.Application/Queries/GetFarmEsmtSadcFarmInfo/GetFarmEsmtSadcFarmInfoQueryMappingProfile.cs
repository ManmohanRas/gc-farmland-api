namespace PresTrust.FarmLand.Application.Queries;
public class GetFarmEsmtSadcFarmInfoQueryMappingProfile:Profile
{ 
    public GetFarmEsmtSadcFarmInfoQueryMappingProfile()
    {
        CreateMap<FarmEsmtSadcFarmInfoEntity, GetFarmEsmtSadcFarmInfoQueryViewModel>();
    }
}
