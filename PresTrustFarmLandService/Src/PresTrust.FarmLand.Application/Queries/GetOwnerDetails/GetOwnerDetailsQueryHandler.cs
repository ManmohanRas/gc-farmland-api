namespace PresTrust.FarmLand.Application.Queries;

public class GetOwnerDetailsQueryHandler : BaseHandler, IRequestHandler<GetOwnerDetailsQuery, GetOwnerDetailsQueryViewModel>
{
    private IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private IOwnerDetailsRepository repoOwner;

    public GetOwnerDetailsQueryHandler(
        IMapper mapper,
        IApplicationRepository repoApplication,
        IOwnerDetailsRepository repoOwner
       ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoOwner = repoOwner;
    }
    public async Task<GetOwnerDetailsQueryViewModel> Handle(GetOwnerDetailsQuery request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);
        // get Owner details
        var reqOwnerDetails = await repoOwner.GetOwnerDetailsAsync(request.ApplicationId);

        var ownerDetails = mapper.Map<IEnumerable<OwnerDetailsEntity>, IEnumerable<OwnerDetails>>(reqOwnerDetails);

        GetOwnerDetailsQueryViewModel result = new GetOwnerDetailsQueryViewModel()
        {
            ApplicationId = application.Id,
            OwnerDetails = ownerDetails,
        };

        return result;
    }
}
