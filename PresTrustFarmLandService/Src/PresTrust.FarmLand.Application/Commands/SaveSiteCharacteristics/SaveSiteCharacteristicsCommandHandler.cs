


namespace PresTrust.FarmLand.Application.Commands;

public class SaveSiteCharacteristicsCommandHandler : BaseHandler, IRequestHandler<SaveSiteCharacteristicsCommand, int>
{

    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private ISiteCharacteristicsRepository repoSiteCharacteristics;


    public SaveSiteCharacteristicsCommandHandler(
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        ISiteCharacteristicsRepository repoSiteCharacteristics

        ):base(repoApplication:repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;      
        this.repoSiteCharacteristics = repoSiteCharacteristics;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ///
    public async Task<int> Handle(SaveSiteCharacteristicsCommand request, CancellationToken cancellationToken)
    {

        var application = await GetIfApplicationExists(request.ApplicationId);

        var reqSiteCharacteristics = mapper.Map<SaveSiteCharacteristicsCommand, SiteCharacteristicsEntity>(request);

        
            reqSiteCharacteristics = await repoSiteCharacteristics.SaveSiteCharacteristicsAsync(reqSiteCharacteristics);


        return reqSiteCharacteristics.Id;

    }
}
