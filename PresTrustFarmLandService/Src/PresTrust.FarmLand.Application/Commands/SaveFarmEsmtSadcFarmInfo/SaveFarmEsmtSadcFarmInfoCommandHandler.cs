
namespace PresTrust.FarmLand.Application.Commands;
public class SaveFarmEsmtSadcFarmInfoCommandHandler :BaseHandler,  IRequestHandler<SaveFarmEsmtSadcFarmInfoCommand, int>
{
   private readonly IMapper mapper;
   private readonly IPresTrustUserContext userContext;
   private IApplicationRepository repoApplication;
   private IFarmEsmtSadcFarmInfoRepository repoFarmInfo;


    public SaveFarmEsmtSadcFarmInfoCommandHandler(
        IMapper mapper,
        IPresTrustUserContext userContext,
        IApplicationRepository repoApplication,
        IFarmEsmtSadcFarmInfoRepository repoFarmInfo
        ):base(repoApplication:repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.repoApplication = repoApplication;
        this.repoFarmInfo = repoFarmInfo;     
    }
    public async Task<int> Handle(SaveFarmEsmtSadcFarmInfoCommand request, CancellationToken cancellationToken)
    {
        userContext.DeriveUserProfileFromUserId(request.UserId);
        var application = await repoApplication.GetApplicationAsync(request.ApplicationId);
        var reqFarmInfo = mapper.Map<SaveFarmEsmtSadcFarmInfoCommand, FarmEsmtSadcFarmInfoEntity>(request);
        reqFarmInfo.LastUpdatedBy = userContext.Email;
        reqFarmInfo = await repoFarmInfo.SaveEsmtSadcFarmInfo(reqFarmInfo);
        return reqFarmInfo.Id;
    }
}
