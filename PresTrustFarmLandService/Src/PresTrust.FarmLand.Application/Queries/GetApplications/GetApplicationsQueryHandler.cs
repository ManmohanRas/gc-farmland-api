namespace PresTrust.FarmLand.Application.Queries
{
    public class GetApplicationsQueryHandler : IRequestHandler<GetApplicationsQuery, List<GetApplicationsQueryViewModel>>
    {
        private readonly IMapper mapper;
        private readonly IApplicationRepository repoApplication;

        public GetApplicationsQueryHandler
            (
            IMapper mapper,
            IApplicationRepository repoApplication
            )
        {
            this.mapper = mapper;
            this.repoApplication = repoApplication;
        }

        public async Task<List<GetApplicationsQueryViewModel>> Handle(GetApplicationsQuery request, CancellationToken cancellationToken)
        {
            var applications = await repoApplication.GetApplicationsAsync();
            var results = mapper.Map<List<FarmLandApplicationEntity>, List<GetApplicationsQueryViewModel>>(applications);
            
            return results;
        }
    }
}
