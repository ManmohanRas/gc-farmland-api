namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppAdminSADCQueryHandler : BaseHandler, IRequestHandler<GetEsmtAppAdminSADCQuery, GetEsmtAppAdminSADCQueryViewModel>
{
    private readonly IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private readonly IEsmtAppAdminSADCRepository repoSADC;

    public GetEsmtAppAdminSADCQueryHandler
       (
             IMapper mapper,
           IEsmtAppAdminSADCRepository repoSADC,
           IApplicationRepository repoApplication
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoSADC = repoSADC;
        this.repoApplication = repoApplication;
    }

    public async Task<GetEsmtAppAdminSADCQueryViewModel> Handle(GetEsmtAppAdminSADCQuery request, CancellationToken cancellationToken)
    {
        EsmtAppAdminSADCEntity results = default;

        var application = await GetIfApplicationExists(request.ApplicationId);
        var reqSADCDetails = await repoSADC.GetEsmtAppAdminSADCDetailsAsync(request.ApplicationId);

        var SADCDetails = mapper.Map<EsmtAppAdminSADCEntity, GetEsmtAppAdminSADCQueryViewModel>(reqSADCDetails);

        return SADCDetails;
    }
}
