namespace PresTrust.FarmLand.Application.Commands
{
    public class SaveFarmSadcAppEligibilityCommandHandler : BaseHandler, IRequestHandler<SaveFarmSadcAppEligibilityCommand, int>
    {
        private readonly IMapper mapper;
        private readonly IFarmSadcAppEligibilityRepository repoAppEligibility;
        private readonly IPresTrustUserContext userContext;
        private readonly IApplicationRepository repoApplication;
        private readonly SystemParameterConfiguration systemParamOptions;


        public SaveFarmSadcAppEligibilityCommandHandler(
           IMapper mapper,
           IFarmSadcAppEligibilityRepository repoAppEligibility,
           IPresTrustUserContext userContext,
           IApplicationRepository repoApplication,
           IOptions<SystemParameterConfiguration> systemParamOptions
           ) : base(repoApplication: repoApplication)
        {
            this.mapper = mapper;
            this.repoAppEligibility = repoAppEligibility;
            this.userContext = userContext;
            this.repoApplication = repoApplication;
            this.systemParamOptions = systemParamOptions.Value;
        }


        public async Task<int> Handle(SaveFarmSadcAppEligibilityCommand request, CancellationToken cancellationToken)
        {
            userContext.DeriveUserProfileFromUserId(request.UserId);
            // get application details
            var application = await GetIfApplicationExists(request.ApplicationId);

            var reqAppEligibility = mapper.Map<SaveFarmSadcAppEligibilityCommand, FarmSadcAppEligibilityEntity>(request);
            reqAppEligibility.LastUpdatedBy = userContext.Email;
            var result = await repoAppEligibility.SaveAsync(reqAppEligibility);
            return result.Id;
        }
    }
}
