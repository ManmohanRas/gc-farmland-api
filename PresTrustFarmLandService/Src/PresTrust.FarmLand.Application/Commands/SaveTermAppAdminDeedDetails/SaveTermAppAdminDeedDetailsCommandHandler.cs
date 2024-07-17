
namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppAdminDeedDetailsCommandHandler : BaseHandler, IRequestHandler<SaveTermAppAdminDeedDetailsCommand , int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermAppAdminDeedDetailsRepository repotermAppAdminDeedDetails;

    public SaveTermAppAdminDeedDetailsCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IApplicationRepository repoApplication,
        ITermAppAdminDeedDetailsRepository repotermAppAdminDeedDetails
    ) : base(repoApplication:repoApplication)
    { 
        this.mapper = mapper;
        this.userContext = userContext;
        this.repoApplication = repoApplication;
        this.repotermAppAdminDeedDetails = repotermAppAdminDeedDetails;
    }

    public async Task<int> Handle(SaveTermAppAdminDeedDetailsCommand request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        var reqDeedDetails = mapper.Map<SaveTermAppAdminDeedDetailsCommand, TermAppAdminDeedDetailsEntity>(request);
        reqDeedDetails = await repotermAppAdminDeedDetails.SaveAsync(reqDeedDetails);
        return reqDeedDetails.Id;
    }
}
