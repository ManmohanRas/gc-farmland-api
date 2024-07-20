
namespace PresTrust.FarmLand.Application.Queries;

public class GetLocationDetailsQueryHandler: IRequestHandler<GetLocationDetailsQuery, GetLocationDetailsQueryViewModel>
{
    private IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private ITermAppLocationRepository repoLocation;

    public GetLocationDetailsQueryHandler
        (
        IMapper mapper,
        IApplicationRepository repoApplication,
        ITermAppLocationRepository repoLocation
        )
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoLocation = repoLocation;
    }

    public async Task<GetLocationDetailsQueryViewModel> Handle(GetLocationDetailsQuery request, CancellationToken cancellationToken)
    {
        GetLocationDetailsQueryViewModel result; 
        var reqParcels = await repoLocation.GetParcelsByFarmID(request.ApplicationId, request.FarmListID);
        var parcels = mapper.Map<List<FarmBlockLotEntity>, List<GetFarmParcelViewModel>>(reqParcels);

        result = new GetLocationDetailsQueryViewModel()
        {
            ApplicationId = request.ApplicationId,
            Parcels = parcels
            
        };      
        return result;
    }
}
