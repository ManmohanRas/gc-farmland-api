namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtAgriEnterpriseQueryHandler : BaseHandler, IRequestHandler<GetFarmEsmtAgriEnterpriseQuery, GetFarmEsmtAgriEnterpriseQueryViewModel>
{
    private IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private IFarmEsmtAgriculturalEnterpriseRepository repoAgricultural;

    public GetFarmEsmtAgriEnterpriseQueryHandler(
        IMapper mapper,
        IApplicationRepository repoApplication,
        IFarmEsmtAgriculturalEnterpriseRepository repoAgricultural
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoAgricultural = repoAgricultural;
    }

    public async Task<GetFarmEsmtAgriEnterpriseQueryViewModel> Handle(GetFarmEsmtAgriEnterpriseQuery request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // get agricultural details
        var agricultural = await this.repoAgricultural.GetAgriEnterprisAsync(request.ApplicationId);
        var agriEnterprise = mapper.Map<FarmEsmtAgriculturalEnterpriseEntity, GetFarmEsmtAgriEnterpriseQueryViewModel>(agricultural);

        //check list
        var agriCheckList = await repoAgricultural.GetAgriCheckListAsync(request.ApplicationId);

        var result = new GetFarmEsmtAgriEnterpriseQueryViewModel()
        {
            ApplicationId = application.Id,
            Id = agriEnterprise.Id,
            AverageGrossReceipts = agriEnterprise.AverageGrossReceipts,
            IsFullTimeFarmer = agriEnterprise.IsFullTimeFarmer,
            HasSoilConservationPlan = agriEnterprise.HasSoilConservationPlan,
            PlanDate = agriEnterprise.PlanDate,
            ConservationPractices = agriEnterprise.ConservationPractices,
            AgriculturalInvestments = agriEnterprise.AgriculturalInvestments,
            AgriCheckList = mapper.Map<IEnumerable<FarmAgriculturalEnterpriseChecklistEntity>, IEnumerable<FarmEsmtAgriCheckListViewModel>>(agriCheckList)
        };

        return result;
    }
}
