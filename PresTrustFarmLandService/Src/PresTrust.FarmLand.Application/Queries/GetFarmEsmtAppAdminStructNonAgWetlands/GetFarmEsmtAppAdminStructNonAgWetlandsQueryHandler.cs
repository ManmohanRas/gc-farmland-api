namespace PresTrust.FarmLand.Application.Queries;
/// <summary>
/// This class handles the query to fetch data and build response
/// </summary>

public class GetFarmEsmtAppAdminStructNonAgWetlandsQueryHandler : BaseHandler, IRequestHandler<GetFarmEsmtAppAdminStructNonAgWetlandsQuery, GetFarmEsmtAppAdminStructNonAgWetlandsQueryViewModel>
{
    private IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private IFarmEsmtAppAdminStructNonAgWetlandsRepository repoWetlands;

    public GetFarmEsmtAppAdminStructNonAgWetlandsQueryHandler(
        IMapper mapper,
        IApplicationRepository repoApplication,
        IFarmEsmtAppAdminStructNonAgWetlandsRepository repoWetlands
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoWetlands = repoWetlands;
    }

    public async Task<GetFarmEsmtAppAdminStructNonAgWetlandsQueryViewModel> Handle(GetFarmEsmtAppAdminStructNonAgWetlandsQuery request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // get wetlands details
        var wetlands = await this.repoWetlands.GetStructNonAgWetlandsAsync(request.ApplicationId);
        var result = mapper.Map<FarmEsmtAppAdminStructNonAgWetlandsEntity, GetFarmEsmtAppAdminStructNonAgWetlandsQueryViewModel>(wetlands);

        return result;
    }
}
