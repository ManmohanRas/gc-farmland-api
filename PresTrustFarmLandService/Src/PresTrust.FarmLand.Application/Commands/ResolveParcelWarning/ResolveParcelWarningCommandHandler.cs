
namespace PresTrust.FarmLand.Application.Commands;

public class ResolveParcelWarningCommandHandler: IRequestHandler<ResolveParcelWarningCommand, bool>
{
    private readonly IMapper mapper;
    private readonly IFarmBlockLotRepository repoBlockLot;

    public ResolveParcelWarningCommandHandler
        (
         IMapper mapper,
         IFarmBlockLotRepository repoBlockLot
        )
    {
        this.mapper = mapper;
        this.repoBlockLot = repoBlockLot;
    }

    public async Task<bool> Handle(ResolveParcelWarningCommand request, CancellationToken cancellationToken)
    {
        await repoBlockLot.ResolveParcelWarning(request.ParcelId);

        return true;

    }
}
