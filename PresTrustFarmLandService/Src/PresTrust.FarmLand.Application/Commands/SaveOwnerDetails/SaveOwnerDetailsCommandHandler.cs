namespace PresTrust.FarmLand.Application.Commands;

public class SaveOwnerDetailsCommandHandler : BaseHandler, IRequestHandler<SaveOwnerDetailsCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private IOwnerDetailsRepository repoOwner;

    public SaveOwnerDetailsCommandHandler
    (
      IMapper mapper,
      IPresTrustUserContext userContext,
      IOptions<SystemParameterConfiguration> systemParamOptions,
      IApplicationRepository repoApplication,
      IOwnerDetailsRepository repoOwner
    ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoOwner = repoOwner;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(SaveOwnerDetailsCommand request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        var reqOwner = mapper.Map<SaveOwnerDetailsCommand, OwnerDetailsEntity>(request);

        reqOwner = await repoOwner.SaveOwnerDetailsAsync(reqOwner);

        return reqOwner.Id;
    }
}

