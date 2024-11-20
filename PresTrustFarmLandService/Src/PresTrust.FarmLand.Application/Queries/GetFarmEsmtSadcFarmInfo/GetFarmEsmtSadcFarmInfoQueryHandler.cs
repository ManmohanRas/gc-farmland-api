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
        //var farmBlockLot = await repoFarmBlockLot.GetFarmBlockLotByIdAsync(request.ApplicationId);
        //farmBlockLot = farmBlockLot ?? new FarmBlockLotEntity();
        var attachmentCList = await repoAttachmentC.GetEsmtAppAttachmentCAsync(request.ApplicationId);
        var attachmentC = attachmentCList.FirstOrDefault() ?? new EsmtAppAttachmentCEntity();

        var ownerDetailsList = await repoOwnerDetails.GetOwnerDetailsAsync(request.ApplicationId);
        var ownerDetails = ownerDetailsList.FirstOrDefault() ?? new OwnerDetailsEntity();
        string FullName = $"{ownerDetails.FirstName},{ownerDetails.LastName}";
        string MailingAdress = $"{ownerDetails.MailingAddress1},{ownerDetails.MailingAddress1},{ownerDetails.State},{ownerDetails.City}, {ownerDetails.ZipCode}";

        var locationBlockLot = await repoLocation.GetParcelsByFarmID(request.ApplicationId,application.FarmListId);

        var BlockLot = locationBlockLot?.FirstOrDefault() != null ? mapper.Map<FarmBlockLotEntity>(locationBlockLot.FirstOrDefault()) :   new FarmBlockLotEntity() ;

        var result = mapper.Map<FarmEsmtSadcFarmInfoEntity, GetFarmEsmtSadcFarmInfoQueryViewModel>(SadcFarmInfo);
        result.PdStreetAddress = esmtOwner.PdStreetAddress;
        result.IsNonAgriPremisesPreserved = attachmentC.IsNonAgriPremisesPreserved;
        result.DescNonAgriUses = attachmentC.DescNonAgriUses;
        result.BlockAndLot = string.Join(",", locationBlockLot.Where(x => x.IsChecked).Select(x => string.Join("&", x.Block, x.Lot))) ?? string.Empty;
        result.Salutation = ownerDetails.Salutation;
        result.FullName = FullName;
        result.Email = ownerDetails.EmailAddress;
        result.PhoneNumber = ownerDetails.PhoneNumber;
        result.MailingAdress = MailingAdress;
        

        //result.FullName = $"{ FullName}";
        //result.MailingAdress = MailingAdress;







        return result;
    }
}
