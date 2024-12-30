namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmMonitoringQueryHandler : IRequestHandler<GetFarmMonitoringQuery, IEnumerable<GetFarmMonitoringQueryViewModel>>
{
        private readonly IMapper mapper;
        private readonly IFarmMonitoringRepository repoFarmMonitoring;

        public GetFarmMonitoringQueryHandler
            (
            IMapper mapper,
            IFarmMonitoringRepository repoFarmMonitoring
            )
        {
            this.mapper = mapper;
            this.repoFarmMonitoring = repoFarmMonitoring;
        }
        public async Task<IEnumerable<GetFarmMonitoringQueryViewModel>> Handle(GetFarmMonitoringQuery request, CancellationToken cancellationToken)
        {
            var farmMonitoring = await repoFarmMonitoring.GetFarmMonitoringAsync();
            var results = mapper.Map<IEnumerable<FarmMonitoringEntity>, IEnumerable<GetFarmMonitoringQueryViewModel>>(farmMonitoring);

            return results;
        }
}
