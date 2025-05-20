namespace PresTrust.FarmLand.Application.Queries;

public class GetSiteCharacteristicsQueryHandler : IRequestHandler<GetSiteCharacteristicsQuery, GetSiteCharacteristicsQueryViewModel>
{

    private readonly IMapper mapper;
    private readonly ISiteCharacteristicsRepository repoSiteCharacteristics;
    private readonly IApplicationRepository repoApplication;
    private IApplicationLocationRepository repoLocation;


    public GetSiteCharacteristicsQueryHandler(IMapper mapper, ISiteCharacteristicsRepository repoSiteCharacteristics, IApplicationRepository repoApplication, IApplicationLocationRepository repoLocation)
    {
        this.mapper = mapper;
        this.repoSiteCharacteristics = repoSiteCharacteristics;
        this.repoApplication = repoApplication;
        this.repoLocation = repoLocation;
    }

    public async Task<GetSiteCharacteristicsQueryViewModel> Handle(GetSiteCharacteristicsQuery request, CancellationToken cancellationToken)
    {   

        var siteCharacteristics = await repoSiteCharacteristics.GetSiteCharacteristicsAsync(request.ApplicationId);
        var application = await repoApplication.GetApplicationAsync(request.ApplicationId);
        var GetDetailsfromLocation = await repoLocation.GetParcelsByFarmID(request.ApplicationId,application.FarmListId);
        var results = mapper.Map<SiteCharacteristicsEntity, GetSiteCharacteristicsQueryViewModel>(siteCharacteristics);
        if (GetDetailsfromLocation.Count() > 0)
        {
            results.Area = GetDetailsfromLocation.Where(x => x.IsChecked).Sum(x => x.AcresToBeAcquired).ToString();

        }else
        {
            results.Area = string.Empty;
        }
           return results;
    }
}
