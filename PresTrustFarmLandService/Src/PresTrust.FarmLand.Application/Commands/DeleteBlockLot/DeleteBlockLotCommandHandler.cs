namespace PresTrust.FarmLand.Application.Commands;

public class DeleteBlockLotCommandHandler : IRequestHandler<DeleteBlockLotCommand, bool>
{
    private readonly IMapper mapper;
    private readonly IFarmBlockLotRepository repoBlockLot;
    private readonly ITermAppAdminDeedDetailsRepository repoDeedDetails;
    private readonly IApplicationLocationRepository repoLocation;

    public DeleteBlockLotCommandHandler
        (
        IMapper mapper,
        IFarmBlockLotRepository repoBlockLot,
        ITermAppAdminDeedDetailsRepository repoDeedDetails,
        IApplicationLocationRepository repoLocation
        )
    {
        this.mapper = mapper;
        this.repoBlockLot = repoBlockLot;
        this.repoDeedDetails = repoDeedDetails;
        this.repoLocation = repoLocation;
    }

    public async Task<bool> Handle(DeleteBlockLotCommand request, CancellationToken cancellationToken)
    {
        await repoBlockLot.DeleteFarmBlockLotById(request.Id);
        if (request.ApplicationId > 0)
        {
            await repoLocation.DeleteAppLocationBlockLot(request.ApplicationId, request.Id);
            await repoDeedDetails.DeleteTermAppDeedLocation(request.ApplicationId, request.Id);

        }


        return true;

    }
}
