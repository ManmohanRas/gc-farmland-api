namespace PresTrust.FarmLand.Application.Queries;

/// <summary>
/// This class handles the query to fetch data and build response
/// </summary>
public class GetTermAppSignatoryQueryHandler : BaseHandler, IRequestHandler<GetTermAppSignatoryQuery, GetTermAppSignatoryQueryViewModel>
{
    private IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private ITermAppSignatoryRepository repoSignatory;

    public GetTermAppSignatoryQueryHandler(
        IMapper mapper,
        IApplicationRepository repoApplication,
        ITermAppSignatoryRepository repoSignatory
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoSignatory = repoSignatory;
    }

    public async Task<GetTermAppSignatoryQueryViewModel> Handle(GetTermAppSignatoryQuery request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // get signatory details
        var signatory = await this.repoSignatory.GetSignatoryAsync(request.ApplicationId);
        var result = mapper.Map<FarmTermAppSignatoryEntity, GetTermAppSignatoryQueryViewModel>(signatory);

        return result;
    }
}

