namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppAdminDetailsCommandHandler :BaseHandler, IRequestHandler<SaveTermAppAdminDetailsCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    //private readonly IOptions<SystemParameterConfiguration> systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private ITermAppAdminDetailsRepository repoTermAppAdminDetails;

    public SaveTermAppAdminDetailsCommandHandler(
        IMapper mapper,
        IPresTrustUserContext userContext,
        //IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        ITermAppAdminDetailsRepository repoTermAppAdminDetails
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        //this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoTermAppAdminDetails = repoTermAppAdminDetails;
    }

    public async Task<int> Handle(SaveTermAppAdminDetailsCommand request, CancellationToken cancellationToken)
    {
        var application = await GetIfApplicationExists(request.ApplicationId);

        var reqTermAppAdminDetails = mapper.Map<SaveTermAppAdminDetailsCommand, FarmTermAppAdminDetailsEntity>(request);
        reqTermAppAdminDetails =  await repoTermAppAdminDetails.SaveTermAppAdminDetailsAsync(reqTermAppAdminDetails);

        return reqTermAppAdminDetails.Id;
    }
}
