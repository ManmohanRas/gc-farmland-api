namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmReSaleQueryHandler : IRequestHandler<GetFarmReSaleQuery, IEnumerable<GetFarmReSaleQueryViewModel>>
{
        private readonly IMapper mapper;
        private readonly IFarmReSaleRepository repoFarmReSale;

        public GetFarmReSaleQueryHandler
            (
            IMapper mapper,
            IFarmReSaleRepository repoFarmReSale
            )
        {
            this.mapper = mapper;
            this.repoFarmReSale = repoFarmReSale;
        }
        public async Task<IEnumerable<GetFarmReSaleQueryViewModel>> Handle(GetFarmReSaleQuery request, CancellationToken cancellationToken)
        {
            var farmReSale = await repoFarmReSale.GetFarmReSaleAsync();
            var results = mapper.Map<IEnumerable<FarmReSaleEntity>, IEnumerable<GetFarmReSaleQueryViewModel>>(farmReSale);

            return results;
        }
}

