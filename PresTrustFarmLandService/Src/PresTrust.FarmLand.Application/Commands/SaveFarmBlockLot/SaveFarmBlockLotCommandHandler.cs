namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmBlockLotCommandHandler: IRequestHandler<SaveFarmBlockLotCommand, SaveFarmBlockLotCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IFarmBlockLotRepository repoBlockLot;

    public SaveFarmBlockLotCommandHandler
        (
        IMapper mapper,
        IFarmBlockLotRepository repoBlockLot
        )
    {
        this.mapper = mapper;
        this.repoBlockLot = repoBlockLot;
    }

    public async Task<SaveFarmBlockLotCommandViewModel> Handle(SaveFarmBlockLotCommand request, CancellationToken cancellationToken)
    {
        SaveFarmBlockLotCommandViewModel result;
        var reqBlockLot = mapper.Map<SaveFarmBlockLotCommand, FarmBlockLotEntity>(request);

        var blockLotParcel = await repoBlockLot.SaveAsync(reqBlockLot);
        result = mapper.Map<FarmBlockLotEntity, SaveFarmBlockLotCommandViewModel>(blockLotParcel);

        return result;

    }
}
