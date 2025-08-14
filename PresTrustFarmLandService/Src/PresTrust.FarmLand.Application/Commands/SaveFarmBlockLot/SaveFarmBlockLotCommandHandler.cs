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
        userContext.DeriveUserProfileFromUserId(request.UserId);
        SaveFarmBlockLotCommandViewModel result = new SaveFarmBlockLotCommandViewModel();

        var reqBlockLot = mapper.Map<SaveFarmBlockLotCommand, FarmBlockLotEntity>(request);
        reqBlockLot.LastUpdatedBy = userContext.Email;

        var currentParcel = await repoBlockLot.GetFarmBlockLotByIdAsync(request.Id);
        currentParcel = currentParcel ?? new FarmBlockLotEntity() { IsClassCodeWarning= false, PropertyClassCode = string.Empty, CorePropertyClassCode = string.Empty};

        bool parcelExists = await repoBlockLot.CheckParcelExists(reqBlockLot.PamsPin, reqBlockLot.FarmListID, request.Id);

        
        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            if (!parcelExists)
            {
                if (request.Id > 0 && currentParcel.PamsPin != reqBlockLot.PamsPin)
                {
                    FarmParcelHistoryEntity reqHistory = new FarmParcelHistoryEntity()
                    {

                        ParcelId = request.Id,
                        CurrentPamsPin = reqBlockLot.PamsPin,
                        PreviousPamsPin = currentParcel.PamsPin,
                        ReasonForChange = currentParcel.ReasonForChange,
                        ChangeType = currentParcel.ChangeType,
                        LastUpdatedBy = userContext.Email
                    };

                    var parcelHistory = await repoParcelHistory.SaveParcelHistoryItemAsync(reqHistory);

                }

                var blockLotParcel = await repoBlockLot.SaveAsync(reqBlockLot);
                blockLotParcel.IsClassCodeWarning = currentParcel.IsClassCodeWarning;
                blockLotParcel.PropertyClassCode = currentParcel.PropertyClassCode;
                blockLotParcel.CorePropertyClassCode = currentParcel.CorePropertyClassCode;

                result = mapper.Map<FarmBlockLotEntity, SaveFarmBlockLotCommandViewModel>(blockLotParcel);
            }
            else
            {
                throw new Exception("Parcel already exists");
            }

            scope.Complete();
        }

        return result;
    }
}
