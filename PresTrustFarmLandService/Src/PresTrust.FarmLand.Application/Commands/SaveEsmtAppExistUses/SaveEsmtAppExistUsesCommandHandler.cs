
namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppExistUsesCommandHandler :BaseHandler, IRequestHandler<SaveEsmtAppExistUsesCommand,int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private IApplicationRepository repoApplication;
    private IEsmtAppExistUsesRepository repoExistUses;

    public SaveEsmtAppExistUsesCommandHandler(IMapper mapper,
        IPresTrustUserContext userContext,
        IApplicationRepository repoApplication,
        IEsmtAppExistUsesRepository repoExistUses
        )
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.repoApplication = repoApplication;
        this.repoExistUses = repoExistUses;
    }

    public async Task<int> Handle(SaveEsmtAppExistUsesCommand request, CancellationToken cancellationToken)
    {
        var application = await repoApplication.GetApplicationAsync(request.ApplicationId);
        var reqExist = mapper.Map<SaveEsmtAppExistUsesCommand, EsmtAppExistUsesEntity>(request);
        reqExist = await repoExistUses.SaveEsmtAppExistUses(reqExist);
        reqExist.LastUpdatedBy = userContext.Email;

        return reqExist.Id;
    }
}
