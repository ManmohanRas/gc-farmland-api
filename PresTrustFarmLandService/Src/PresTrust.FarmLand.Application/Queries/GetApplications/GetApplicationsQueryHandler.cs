namespace PresTrust.FarmLand.Application.Queries;

public class GetApplicationsQueryHandler : IRequestHandler<GetApplicationsQuery, List<GetApplicationsQueryViewModel>>
{
    private readonly IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private readonly IPresTrustUserContext userContext;


    public GetApplicationsQueryHandler
        (
        IMapper mapper,
        IApplicationRepository repoApplication,
        IPresTrustUserContext userContext
        )
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.userContext = userContext;
    }

    public async Task<List<GetApplicationsQueryViewModel>> Handle(GetApplicationsQuery request, CancellationToken cancellationToken)
    {
        var applications = await repoApplication.GetApplicationsAsync(userContext.AgencyIds, userContext.IsExternalUser);
        var results = mapper.Map<List<FarmApplicationEntity>, List<GetApplicationsQueryViewModel>>(applications);

        return results;
    }
}
