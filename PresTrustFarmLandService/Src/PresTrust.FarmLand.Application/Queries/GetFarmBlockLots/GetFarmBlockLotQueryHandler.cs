namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmBlockLotQueryHandler: IRequestHandler<GetFarmBlockLotQuery, IEnumerable<GetFarmBlockLotQueryViewModel>>
{
    private readonly IMapper mapper;
    private readonly IFarmBlockLotRepository repoBlockLot;

    public GetFarmBlockLotQueryHandler
        (
        IMapper mapper,
        IFarmBlockLotRepository repoBlockLot
        )
    {
        this.mapper = mapper;
        this.repoBlockLot = repoBlockLot;
    }

    public async Task<IEnumerable<GetFarmBlockLotQueryViewModel>> Handle(GetFarmBlockLotQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<GetFarmBlockLotQueryViewModel> result;
        var reqParcels = await repoBlockLot.GetFarmBlockLotAsync();

        var parcels = mapper.Map<IEnumerable<FarmBlockLotEntity>, IEnumerable<GetFarmBlockLotQueryViewModel>>(reqParcels);
        result = parcels.ToList();
        return result;
    }
}
