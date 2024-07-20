
namespace PresTrust.FarmLand.Application.Commands;

public class SaveLocationDetailsCommandHandler : IRequestHandler<SaveLocationDetailsCommand, Unit>
{
    private IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private ITermAppLocationRepository repoLocation;
    private readonly IPresTrustUserContext userContext;


    public SaveLocationDetailsCommandHandler
        (
            IMapper mapper,
            IApplicationRepository repoApplication,
            ITermAppLocationRepository repoLocation,
            IPresTrustUserContext userContext
        )
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoLocation = repoLocation;
        this.userContext = userContext;
    }
    public async Task<Unit> Handle(SaveLocationDetailsCommand request, CancellationToken cancellationToken)
    {
        var parcels =  mapper.Map<List<SaveBlockLot>, List<FarmTermAppLocationEntity>>(request.Parcels);

        var checkLocationParcel = await repoLocation.CheckLocationParcel(request.ApplicationId, parcels);


        return Unit.Value;
    }
}
