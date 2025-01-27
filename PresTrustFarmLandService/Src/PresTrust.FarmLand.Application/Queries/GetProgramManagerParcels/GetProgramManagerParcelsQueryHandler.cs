namespace PresTrust.FarmLand.Application.Queries;

public class GetProgramManagerParcelsQueryHandler : IRequestHandler<GetProgramManagerParcelsQuery, IEnumerable<GetProgramManagerParcelsQueryViewModel>>
{
    private readonly IMapper mapper;
    private readonly IFarmBlockLotRepository repoBlockLot;

    public GetProgramManagerParcelsQueryHandler
        (
        IMapper mapper,
        IFarmBlockLotRepository repoBlockLot
        )
    {
        this.mapper = mapper;
        this.repoBlockLot = repoBlockLot;   
    }
    public async Task<IEnumerable<GetProgramManagerParcelsQueryViewModel>> Handle(GetProgramManagerParcelsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<GetProgramManagerParcelsQueryViewModel> result;
        var reqParcels = await repoBlockLot.GetProgramManagerBlockLotAsync();

        var parcels = mapper.Map<IEnumerable<FarmBlockLotEntity>, IEnumerable<GetProgramManagerParcelsQueryViewModel>>(reqParcels);
        result = parcels.ToList();
        return result;
    }
}
