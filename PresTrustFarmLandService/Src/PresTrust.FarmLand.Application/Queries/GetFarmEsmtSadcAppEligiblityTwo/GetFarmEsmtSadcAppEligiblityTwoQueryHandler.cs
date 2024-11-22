
namespace PresTrust.FarmLand.Application.Queries;
public class GetFarmEsmtSadcAppEligiblityTwoQueryHandler :BaseHandler, IRequestHandler<GetFarmEsmtSadcAppEligiblityTwoQuery, GetFarmEsmtSadcAppEligiblityTwoQueryViewModel>
{  private readonly IMapper mapper;
   private IFarmEsmtSadcAppEligiblityTwoRepository repoEligiblityTwo;
   private IApplicationRepository repoApplication;


    public GetFarmEsmtSadcAppEligiblityTwoQueryHandler
    ( 
        IMapper mapper,
        IFarmEsmtSadcAppEligiblityTwoRepository repoEligiblityTwo,
        IApplicationRepository repoApplication
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoEligiblityTwo = repoEligiblityTwo;
    }
    public async Task<GetFarmEsmtSadcAppEligiblityTwoQueryViewModel> Handle(GetFarmEsmtSadcAppEligiblityTwoQuery request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        var reqEligbilityTwo = await repoEligiblityTwo.GetSadcEligiblityTwoAsync(request.ApplicationId);
        var EligbilityTwo = mapper.Map<FarmEsmtSadcAppEligiblityTwoEntity, GetFarmEsmtSadcAppEligiblityTwoQueryViewModel>(reqEligbilityTwo);

        return EligbilityTwo;
    }
}
