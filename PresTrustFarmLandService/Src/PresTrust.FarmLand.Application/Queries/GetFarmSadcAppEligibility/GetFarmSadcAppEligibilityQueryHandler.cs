namespace PresTrust.FarmLand.Application.Queries
{
    public class GetFarmSadcAppEligibilityQueryHandlerBaseHandler : BaseHandler, IRequestHandler<GetFarmSadcAppEligibilityQuery, GetFarmSadcAppEligibilityQueryViewModel>
    {
        private IMapper mapper;
        private readonly IApplicationRepository repoApplication;
        private IFarmSadcAppEligibilityRepository repoAppEligibility;

        public GetFarmSadcAppEligibilityQueryHandlerBaseHandler(
            IMapper mapper,
            IApplicationRepository repoApplication,
            IFarmSadcAppEligibilityRepository repoAppEligibility
            ) : base(repoApplication: repoApplication)
        {
            this.mapper = mapper;
            this.repoAppEligibility = repoAppEligibility;
        }

        public async Task<GetFarmSadcAppEligibilityQueryViewModel> Handle(GetFarmSadcAppEligibilityQuery request, CancellationToken cancellationToken)
        {
            // get application details
            var application = await GetIfApplicationExists(request.ApplicationId);

            // get AdminDetails details
            var appEligibilityDetauls = await this.repoAppEligibility.GetAppEligibilityDetailsAsync(request.ApplicationId);
            var result = mapper.Map<FarmSadcAppEligibilityEntity, GetFarmSadcAppEligibilityQueryViewModel>(appEligibilityDetauls);

            return result;
        }
    }
}
