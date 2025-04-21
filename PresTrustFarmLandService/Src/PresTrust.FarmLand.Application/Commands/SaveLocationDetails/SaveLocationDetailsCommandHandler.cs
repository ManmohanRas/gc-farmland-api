namespace PresTrust.FarmLand.Application.Commands;

public class SaveLocationDetailsCommandHandler : BaseHandler, IRequestHandler<SaveLocationDetailsCommand, Unit>
{
    private IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private IApplicationLocationRepository repoLocation;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly ITermAppAdminDeedDetailsRepository repoDeedDetails;
    private readonly IFarmBlockLotRepository repoBlockLot;


    public SaveLocationDetailsCommandHandler
        (
            IMapper mapper,
            IApplicationRepository repoApplication,
            IApplicationLocationRepository repoLocation,
            ITermBrokenRuleRepository repoBrokenRules,
            IPresTrustUserContext userContext,
            ITermAppAdminDeedDetailsRepository repoDeedDetails,
            IOptions<SystemParameterConfiguration> systemParamOptions
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoLocation = repoLocation;
        this.repoBrokenRules = repoBrokenRules;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoDeedDetails = repoDeedDetails;
    }
    public async Task<Unit> Handle(SaveLocationDetailsCommand request, CancellationToken cancellationToken)
    {
        List<FarmTermAppDeedLocationEntity> deedParcels = new List<FarmTermAppDeedLocationEntity>();
        FarmTermAppDeedLocationEntity deed = new FarmTermAppDeedLocationEntity();

        var application = await GetIfApplicationExists(request.ApplicationId);

        var parcels =  mapper.Map<List<SaveBlockLot>, List<FarmAppLocationDetailsEntity>>(request.Parcels);

        deedParcels = await repoDeedDetails.GetTermAppAdminDeedLocationDetails(request.ApplicationId);

        var reqParcels = await repoLocation.GetUnLinkedParcelsByFarmID(application.Id, application.FarmListId, application.ApplicationTypeId);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            foreach (var parcel in parcels)
            {
                parcel.FarmListID = application.FarmListId;
                
               
                if (parcel.RowStatus == "I")
                {
                    deed.ApplicationId = application.Id;
                    deed.ParcelId = parcel.ParcelId;
                    deed.IsChecked  = parcel.IsChecked;
                    if(deedParcels.Count() > 0)
                    {
                        deed.DeedId = deedParcels.Where(x => x.ParcelId == parcel.ParcelId).Select(x => x.DeedId).FirstOrDefault();
                    }else
                    {
                        deed.DeedId = 0;
                    }
                    await repoDeedDetails.CheckDeedLocationParcel(request.ApplicationId, deed);

                }
                else if (parcel.RowStatus == "D")
                {
                     //await repoLocation.DeleteAppLocationBlockLot(request.ApplicationId, parcel.ParcelId);
                     await repoDeedDetails.UpdateTermAppDeedLocation(request.ApplicationId, parcel.ParcelId, parcel.IsChecked);

                }
                await repoLocation.CheckLocationParcel(request.ApplicationId, parcel);

            }


            var brokenRules = await ReturnBrokenRulesIfAny(application);

            dynamic section = application.ApplicationTypeId == 1 ? TermAppSectionEnum.LOCATION : EsmtAppSectionEnum.LOCATION;



            await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, section);

            await repoBrokenRules.SaveBrokenRules(brokenRules);
            scope.Complete();

        }

        return Unit.Value;
    }

    private async Task<List<FarmBrokenRuleEntity>> ReturnBrokenRulesIfAny(FarmApplicationEntity application)
    {
        dynamic sectionId = application.ApplicationTypeId == 1 ? (int) TermAppSectionEnum.LOCATION :(int) EsmtAppSectionEnum.LOCATION;



        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();

        var getLocationBlockLots = await repoLocation.GetParcelsByFarmID(application.Id, application.FarmListId);


        if (getLocationBlockLots.Where(x => x.IsChecked).Count() <= 0)
        {
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = application.Id,
                SectionId = sectionId,
                Message = "At least One Record Should be selected in Location tab.",
                IsApplicantFlow = false
            });

        }

        return brokenRules;

    }
}
