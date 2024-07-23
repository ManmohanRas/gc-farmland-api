namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmBlockLotCommandHandler: IRequestHandler<SaveFarmBlockLotCommand, SaveFarmBlockLotCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IFarmBlockLotRepository repoBlockLot;
    private readonly IFarmParcelHistoryRepository repoParcelHistory;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IPresTrustUserContext userContext;

    public SaveFarmBlockLotCommandHandler
        (
        IMapper mapper,
        IFarmBlockLotRepository repoBlockLot,
        IFarmParcelHistoryRepository repoParcelHistory,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IPresTrustUserContext userContext
        )
    {
        this.mapper = mapper;
        this.repoBlockLot = repoBlockLot;
        this.repoParcelHistory = repoParcelHistory;
        this.systemParamOptions = systemParamOptions.Value;
        this.userContext = userContext;
    }

    public async Task<SaveFarmBlockLotCommandViewModel> Handle(SaveFarmBlockLotCommand request, CancellationToken cancellationToken)
    {
        SaveFarmBlockLotCommandViewModel result;
        var reqBlockLot = mapper.Map<SaveFarmBlockLotCommand, FarmBlockLotEntity>(request);

        var currentParcel = await repoBlockLot.GetFarmBlockLotByIdAsync(request.Id);

        FarmParcelHistoryEntity reqHistory = new FarmParcelHistoryEntity()
        {

            ParcelId = request.Id,
            CurrentPamsPin = currentParcel.PamsPin,
            PreviousPamsPin = reqBlockLot.PamsPin,
            ReasonForChange = currentParcel.ReasonForChange,
            LastUpdatedBy = userContext.Email
        };
        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            if (request.Id > 0)
            {
                var parcelHistory = await repoParcelHistory.SaveParcelHistoryItemAsync(reqHistory);

            }

            var blockLotParcel = await repoBlockLot.SaveAsync(reqBlockLot);

            result = mapper.Map<FarmBlockLotEntity, SaveFarmBlockLotCommandViewModel>(blockLotParcel);

            scope.Complete();
        }


        return result;

    }
}
