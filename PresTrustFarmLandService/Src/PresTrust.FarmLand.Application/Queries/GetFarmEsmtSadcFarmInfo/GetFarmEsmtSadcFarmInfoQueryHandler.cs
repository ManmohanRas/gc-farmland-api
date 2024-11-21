namespace PresTrust.FarmLand.Application.Queries;
public class GetFarmEsmtSadcFarmInfoQueryHandler : BaseHandler,IRequestHandler<GetFarmEsmtSadcFarmInfoQuery, GetFarmEsmtSadcFarmInfoQueryViewModel>
{
    private readonly IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private readonly IFarmEsmtSadcFarmInfoRepository repoFarmInfo;
    private readonly IEsmtAppAttachmentCRepository repoAttachmentC;
    private readonly IOwnerDetailsRepository repoOwnerDetails;
    private readonly IEsmtOwnerDetailsRepository repoEsmtOwner;
    private readonly IFarmBlockLotRepository repoFarmBlockLot;
    private IApplicationLocationRepository repoLocation;

    public GetFarmEsmtSadcFarmInfoQueryHandler(
        IMapper mapper,
        IApplicationRepository repoApplication,
        IFarmEsmtSadcFarmInfoRepository repoFarmInfo,
        IEsmtAppAttachmentCRepository repoAttachmentC,
        IOwnerDetailsRepository repoOwnerDetails,
        IEsmtOwnerDetailsRepository repoEsmtOwner,
        IFarmBlockLotRepository repoFarmBlockLot,
        IApplicationLocationRepository repoLocation


    ) :base(repoApplication:repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication; 
        this.repoFarmInfo = repoFarmInfo;
        this.repoAttachmentC = repoAttachmentC;
        this.repoOwnerDetails = repoOwnerDetails;
        this.repoEsmtOwner = repoEsmtOwner;
        this.repoFarmBlockLot = repoFarmBlockLot;
        this.repoLocation = repoLocation;
    }
    public async Task<GetFarmEsmtSadcFarmInfoQueryViewModel> Handle(GetFarmEsmtSadcFarmInfoQuery request, CancellationToken cancellationToken)
    {
        var application = await repoApplication.GetApplicationAsync(request.ApplicationId);
        var SadcFarmInfo = await repoFarmInfo.GetEsmtSadcFarmInfo(request.ApplicationId);
        var esmtOwner = await repoEsmtOwner.GetOwnerDetailsAsync(request.ApplicationId);
        esmtOwner = esmtOwner ?? new EsmtOwnerDetailsEntity();
        var attachmentCList = await repoAttachmentC.GetEsmtAppAttachmentCAsync(request.ApplicationId);
        var attachmentC = attachmentCList.FirstOrDefault() ?? new EsmtAppAttachmentCEntity();
        var ownerDetailsList = await repoOwnerDetails.GetOwnerDetailsAsync(request.ApplicationId);
        var ownerDetails = ownerDetailsList.FirstOrDefault() ?? new OwnerDetailsEntity();
        var locationBlockLot = await repoLocation.GetParcelsByFarmID(request.ApplicationId,application.FarmListId);
        var BlockLot = locationBlockLot?.FirstOrDefault() != null ? mapper.Map<FarmBlockLotEntity>(locationBlockLot.FirstOrDefault()) :   new FarmBlockLotEntity() ;
        var result = mapper.Map<FarmEsmtSadcFarmInfoEntity, GetFarmEsmtSadcFarmInfoQueryViewModel>(SadcFarmInfo);
        result.PdStreetAddress = esmtOwner.PdStreetAddress;
        result.IsNonAgriPremisesPreserved = attachmentC.IsNonAgriPremisesPreserved;
        result.DescNonAgriUses = attachmentC.DescNonAgriUses;
        result.BlockAndLot = string.Join(",", locationBlockLot.Where(x => x.IsChecked).Select(x => string.Join("&", x.Block, x.Lot))) ?? string.Empty;
        result.Salutation = ownerDetails.Salutation;
        result.FullName = string.Join( ",",ownerDetailsList.Select(x => string.Join(",", x.FirstName, x.LastName))) ?? string.Empty;       
        result.Email = ownerDetails.EmailAddress;
        result.PhoneNumber = ownerDetails.PhoneNumber;
        result.MailingAdress = string.Join(",", ownerDetailsList.Select(x => string.Join(",", x.MailingAddress1, x.MailingAddress2, x.State, x.City, x.ZipCode))) ?? string.Empty;        
        return result;
    }
}
