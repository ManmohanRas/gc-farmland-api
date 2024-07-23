
using static System.Collections.Specialized.BitVector32;

namespace PresTrust.FarmLand.Application.Commands;

public class SaveLocationDetailsCommandHandler : BaseHandler, IRequestHandler<SaveLocationDetailsCommand, Unit>
{
    private IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private ITermAppLocationRepository repoLocation;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;


    public SaveLocationDetailsCommandHandler
        (
            IMapper mapper,
            IApplicationRepository repoApplication,
            ITermAppLocationRepository repoLocation,
            ITermBrokenRuleRepository repoBrokenRules,
            IPresTrustUserContext userContext,
            IOptions<SystemParameterConfiguration> systemParamOptions
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoLocation = repoLocation;
        this.repoBrokenRules = repoBrokenRules;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
    }
    public async Task<Unit> Handle(SaveLocationDetailsCommand request, CancellationToken cancellationToken)
    {
        var application = await GetIfApplicationExists(request.ApplicationId);

        var parcels =  mapper.Map<List<SaveBlockLot>, List<FarmTermAppLocationEntity>>(request.Parcels);

        int sectionId = (int)ApplicationSectionEnum.LOCATION;
        List<TermBrokenRuleEntity> brokenRules = new List<TermBrokenRuleEntity>();

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
           
            foreach(var parcel in parcels)
            {
                if ( parcel.RowStatus == "I")
                {
                    parcel.FarmListID = application.FarmListId;
                    await repoLocation.CheckLocationParcel(request.ApplicationId, parcel);
                }else if (parcel.RowStatus == "D")
                {
                     await repoLocation.DeleteTermAppLocationBlockLot(request.ApplicationId, parcel.ParcelId);

                }
            }

            var getLocationBlockLots = await repoLocation.GetParcelsByFarmID(application.Id, application.FarmListId);

            if (getLocationBlockLots.Where(x => x.IsChecked).Count() == 0)
            {
                brokenRules.Add(new TermBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "At least One Record Should be selected in Location tab.",
                    IsApplicantFlow = false
                });

            }
            await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, ApplicationSectionEnum.LOCATION);
            await repoBrokenRules.SaveBrokenRules(brokenRules);
            scope.Complete();

        }

        return Unit.Value;
    }

}
