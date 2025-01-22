namespace PresTrust.FarmLand.Application.Queries;

public class GetProgramManagerParcelsQueryMappingProfile: Profile
{
    public GetProgramManagerParcelsQueryMappingProfile()
    {
        CreateMap<FarmBlockLotEntity, GetProgramManagerParcelsQueryViewModel>();
    }
}
