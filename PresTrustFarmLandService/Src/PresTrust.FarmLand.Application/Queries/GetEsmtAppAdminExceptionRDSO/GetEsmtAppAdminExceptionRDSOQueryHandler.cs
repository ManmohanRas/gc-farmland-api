namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppAdminExceptionRDSOQueryHandler : BaseHandler, IRequestHandler<GetEsmtAppAdminExceptionRDSOQuery, GetEsmtAppAdminExceptionRDSOQueryViewModel>
{
    private readonly IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private readonly IEsmtAppAdminExceptionRDSORepository repoExceptionRDSO;

    public GetEsmtAppAdminExceptionRDSOQueryHandler
       (
             IMapper mapper,
           IEsmtAppAdminExceptionRDSORepository repoExceptionRDSO,
           IApplicationRepository repoApplication
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoExceptionRDSO = repoExceptionRDSO;
        this.repoApplication = repoApplication;
    }

    public async Task<GetEsmtAppAdminExceptionRDSOQueryViewModel> Handle(GetEsmtAppAdminExceptionRDSOQuery request, CancellationToken cancellationToken)
    {
        EsmtAppAdminExceptionRDSOEntity results = default;

        var application = await GetIfApplicationExists(request.ApplicationId);
        var reqExceptionRDSODetails = await repoExceptionRDSO.GetEsmtAppAdminExceptionRDSODetailsAsync(request.ApplicationId);

        var exceptionRDSODetails = mapper.Map<EsmtAppAdminExceptionRDSOEntity, GetEsmtAppAdminExceptionRDSOQueryViewModel>(reqExceptionRDSODetails);

        return exceptionRDSODetails;
    }
}
