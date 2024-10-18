namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppAdminCostDetailsQueryHandler : BaseHandler, IRequestHandler<GetEsmtAppAdminCostDetailsQuery, GetEsmtAppAdminCostDetailsQueryViewModel>
{
    private IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private IFarmEsmtAppAdminCostDetailsRepository repoCostDetails;

    public GetEsmtAppAdminCostDetailsQueryHandler(
        IMapper mapper,
        IApplicationRepository repoApplication,
        IFarmEsmtAppAdminCostDetailsRepository repoCostDetails
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoCostDetails = repoCostDetails;
    }

    public async Task<GetEsmtAppAdminCostDetailsQueryViewModel> Handle(GetEsmtAppAdminCostDetailsQuery request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // get CostDetails details
        var costDetails = await this.repoCostDetails.GetCostDetailsAsync(request.ApplicationId);
        var result = mapper.Map<FarmEsmtAppAdminCostDetailsEntity, GetEsmtAppAdminCostDetailsQueryViewModel>(costDetails);

        return result;
    }
}
