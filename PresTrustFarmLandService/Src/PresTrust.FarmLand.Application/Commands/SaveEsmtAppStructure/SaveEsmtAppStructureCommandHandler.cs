namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppStructureCommandHandler : BaseHandler, IRequestHandler<SaveEsmtAppStructureCommand, int>
{

    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private IApplicationRepository repoApplication;
    private IEsmtAppStructureRepository repoStructure;

    public SaveEsmtAppStructureCommandHandler(
        IMapper mapper,
        IPresTrustUserContext userContext,
        IApplicationRepository repoApplication,
        IEsmtAppStructureRepository repoStructure):base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.repoApplication = repoApplication;
        this.repoStructure = repoStructure;

    }
    public async Task<int> Handle(SaveEsmtAppStructureCommand request, CancellationToken cancellationToken)
    {

        var application = await repoApplication.GetApplicationAsync(request.ApplicationId);
        var reqStructure = mapper.Map<SaveEsmtAppStructureCommand, EsmtStructureAppEntity>(request);
        reqStructure = await repoStructure.SaveEsmtStructureEntityAsync(reqStructure);
        reqStructure.LastUpdatedBy = userContext.Email;

        return reqStructure.Id;
    }
}
