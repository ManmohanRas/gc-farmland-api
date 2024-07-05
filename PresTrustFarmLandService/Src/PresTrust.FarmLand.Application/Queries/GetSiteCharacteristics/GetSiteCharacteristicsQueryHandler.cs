namespace PresTrust.FarmLand.Application.Queries;

public class GetSiteCharacteristicsQueryHandler : IRequestHandler<GetSiteCharacteristicsQuery, GetSiteCharacteristicsQueryViewModel>
{

    private readonly IMapper mapper;
    private readonly ISiteCharacteristicsRepository repoSiteCharacteristics;
    private readonly IApplicationRepository applicationRepository;
    

    public GetSiteCharacteristicsQueryHandler(IMapper mapper, ISiteCharacteristicsRepository repoSiteCharacteristics, IApplicationRepository applicationRepository)
    {
        this.mapper = mapper;
        this.repoSiteCharacteristics = repoSiteCharacteristics;
        this.applicationRepository = applicationRepository;
    }

    public async Task<GetSiteCharacteristicsQueryViewModel> Handle(GetSiteCharacteristicsQuery request, CancellationToken cancellationToken)
    {   

    var siteCharacteristics = await repoSiteCharacteristics.GetSiteCharacteristicsAsync(request.ApplicationId);
        var results = mapper.Map<SiteCharacteristicsEntity, GetSiteCharacteristicsQueryViewModel>(siteCharacteristics);

        return results;
    }
}


//public int ApplicationId { get; set; }