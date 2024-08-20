namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtOwnerDetailsCommandHandler : BaseHandler, IRequestHandler<SaveEsmtOwnerDetailsCommand, int>
{
    private IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private IEsmtOwnerDetailsRepository repoOwner;

    public SaveEsmtOwnerDetailsCommandHandler(
       IMapper mapper,
       IPresTrustUserContext userContext,
       IOptions<SystemParameterConfiguration> systemParamOptions,
       IApplicationRepository repoApplication,
       IEsmtOwnerDetailsRepository repoOwner
      ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoOwner = repoOwner;
    }

    public async Task<int> Handle(SaveEsmtOwnerDetailsCommand request, CancellationToken cancellationToken)
    {

        var application = await GetIfApplicationExists(request.ApplicationId);

        var reqEsmtOwner = mapper.Map<SaveEsmtOwnerDetailsCommand, EsmtOwnerDetailsEntity>(request);

        reqEsmtOwner = await repoOwner.SaveOwnerDetailsAsync(reqEsmtOwner);

        return reqEsmtOwner.Id;

    }

}
