namespace PresTrust.FarmLand.Application.Queries
{
    public class GetFarmListQueryHandler : IRequestHandler<GetFarmListQuery, IEnumerable<GetFarmListQueryViewModel>>
    {
        private readonly IMapper mapper;
        private readonly IFarmListRepository repoFarmList;

        public GetFarmListQueryHandler
            (
            IMapper mapper,
            IFarmListRepository repoFarmList
            )
        {
            this.mapper = mapper;
            this.repoFarmList = repoFarmList;
        }
        public async Task<IEnumerable<GetFarmListQueryViewModel>> Handle(GetFarmListQuery request, CancellationToken cancellationToken)
        {
            var farmList = await repoFarmList.GetFarmListAsync();
            var results  = mapper.Map<IEnumerable<FarmListEntity>, IEnumerable<GetFarmListQueryViewModel>>(farmList);

            return results;
        }
    }
}
