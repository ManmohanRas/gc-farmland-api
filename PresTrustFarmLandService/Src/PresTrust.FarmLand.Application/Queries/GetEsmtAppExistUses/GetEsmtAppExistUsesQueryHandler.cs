using MediatR;

namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppExistUsesQueryHandler : BaseHandler, IRequestHandler<GetEsmtAppExistUsesQuery, GetEsmtAppExistUsesQueryViewModel>
{
    IMapper mapper;
    public IEsmtAppExistUsesRepository repoExistUses;
    private readonly IApplicationRepository repoApplication;
    
    public GetEsmtAppExistUsesQueryHandler(
          IMapper mapper,
         IApplicationRepository repoApplication,
         IEsmtAppExistUsesRepository repoExistUses
        ):base(repoApplication : repoApplication)
    {
        this.mapper = mapper;
        this.repoExistUses = repoExistUses;
        this.repoApplication = repoApplication;

    }
    public async Task<GetEsmtAppExistUsesQueryViewModel> Handle(GetEsmtAppExistUsesQuery request, CancellationToken cancellationToken)
    {
        var application = await repoApplication.GetApplicationAsync(request.ApplicationId);
        var existUses = await repoExistUses.GetEsmtAppExistUses(application.Id);
        var result = mapper.Map<EsmtAppExistUsesEntity, GetEsmtAppExistUsesQueryViewModel>(existUses);    
        return result;
    }
}
