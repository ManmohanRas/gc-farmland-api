namespace PresTrust.FarmLand.Application.Queries;

public class GetParcelHistoryQueryMappingProfile: Profile
{
    public GetParcelHistoryQueryMappingProfile()
    {
        CreateMap<FarmParcelHistoryEntity, GetParcelHistoryQueryViewModel>();
    }
}
