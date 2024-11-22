
namespace PresTrust.FarmLand.Application.Commands;
public class SaveFarmEsmtSadcAppEligiblityTwoCommandHandler :BaseHandler, IRequestHandler<SaveFarmEsmtSadcAppEligiblityTwoCommand, int>
{
    private readonly IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private IFarmEsmtSadcAppEligiblityTwoRepository repoEligibilityTwo;
    private readonly IPresTrustUserContext userContext;


    public SaveFarmEsmtSadcAppEligiblityTwoCommandHandler
    (
     IMapper mapper,
     IApplicationRepository repoApplication,
     IFarmEsmtSadcAppEligiblityTwoRepository repoEligibilityTwo,
     IPresTrustUserContext userContext
     ) : base(repoApplication: repoApplication)
    {
      this.mapper = mapper;
      this.repoApplication = repoApplication;
      this.repoEligibilityTwo = repoEligibilityTwo;
     this.userContext = userContext;    
    }
    public async Task<int> Handle(SaveFarmEsmtSadcAppEligiblityTwoCommand request, CancellationToken cancellationToken)
    {
        var reqEligibilityTwo = mapper.Map<SaveFarmEsmtSadcAppEligiblityTwoCommand, FarmEsmtSadcAppEligiblityTwoEntity>(request);
        reqEligibilityTwo.LastUpdatedBy = userContext.Email;
        var EligibilityTwo = await repoEligibilityTwo.SaveSadcEligibilityTwoAsync(reqEligibilityTwo);
        return EligibilityTwo.Id;

    }
}
