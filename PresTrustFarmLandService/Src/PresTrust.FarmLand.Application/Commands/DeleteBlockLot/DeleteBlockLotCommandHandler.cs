namespace PresTrust.FarmLand.Application.Commands;

public class DeleteBlockLotCommandHandler : IRequestHandler<DeleteBlockLotCommand, bool>
{
    private readonly IMapper mapper;
    private readonly IFarmBlockLotRepository repoBlockLot;

    public DeleteBlockLotCommandHandler
        (
        IMapper mapper,
        IFarmBlockLotRepository repoBlockLot
        )
    {
        this.mapper = mapper;
        this.repoBlockLot = repoBlockLot;
    }

    public async Task<bool> Handle(DeleteBlockLotCommand request, CancellationToken cancellationToken)
    {
        await repoBlockLot.DeleteFarmBlockLotById(request.Id);
        
            return true;

    }
}
