namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtOwnerDetailsQueryHandler : BaseHandler, IRequestHandler<GetEsmtOwnerDetailsQuery, GetEsmtOwnerDetailsQueryViewModel>
{
    private IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private IEsmtOwnerDetailsRepository repoOwner;

    public GetEsmtOwnerDetailsQueryHandler(
       IMapper mapper,
       IApplicationRepository repoApplication,
       IEsmtOwnerDetailsRepository repoOwner
      ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoOwner = repoOwner;
    }
    public async Task<GetEsmtOwnerDetailsQueryViewModel> Handle(GetEsmtOwnerDetailsQuery request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);


        var results = await this.repoOwner.GetOwnerDetailsAsync(request.ApplicationId);

        var owner = mapper.Map <EsmtOwnerDetailsEntity, GetEsmtOwnerDetailsQueryViewModel>(results);

       
        return owner;
    }

}
