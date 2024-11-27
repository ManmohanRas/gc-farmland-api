
namespace PresTrust.FarmLand.Application.Queries;

public class GetLocationDetailsQueryHandler: BaseHandler, IRequestHandler<GetLocationDetailsQuery, GetLocationDetailsQueryViewModel>
{
    private IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private IApplicationLocationRepository repoLocation;

    public GetLocationDetailsQueryHandler
        (
        IMapper mapper,
        IApplicationRepository repoApplication,
        IApplicationLocationRepository repoLocation
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoLocation = repoLocation;
    }

    public async Task<GetLocationDetailsQueryViewModel> Handle(GetLocationDetailsQuery request, CancellationToken cancellationToken)
    {
        var application = await GetIfApplicationExists(request.ApplicationId);

        GetLocationDetailsQueryViewModel result; 
        var reqParcels = await repoLocation.GetUnLinkedParcelsByFarmID(application.Id, request.FarmListID, application.ApplicationTypeId);
        var parcels = mapper.Map<List<FarmBlockLotEntity>, List<GetFarmParcelViewModel>>(reqParcels);

        result = new GetLocationDetailsQueryViewModel()
        {
            ApplicationId = request.ApplicationId,
            Parcels = parcels
            
        };      
        return result;
    }
}
