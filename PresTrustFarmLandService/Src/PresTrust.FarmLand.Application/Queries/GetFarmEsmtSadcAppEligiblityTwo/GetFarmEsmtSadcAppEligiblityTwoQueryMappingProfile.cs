namespace PresTrust.FarmLand.Application.Queries;
public class GetFarmEsmtSadcAppEligiblityTwoQueryMappingProfile:Profile
{
    public GetFarmEsmtSadcAppEligiblityTwoQueryMappingProfile()
    {
        CreateMap<FarmEsmtSadcAppEligiblityTwoEntity, GetFarmEsmtSadcAppEligiblityTwoQueryViewModel>();
    }
}
