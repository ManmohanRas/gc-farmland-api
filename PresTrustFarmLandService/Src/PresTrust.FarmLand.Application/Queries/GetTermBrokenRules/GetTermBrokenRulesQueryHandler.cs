namespace PresTrust.FarmLand.Application.Queries;
using System.Collections.Generic;
using System.Linq;

public class GetTermBrokenRulesQueryHandler : BaseHandler, IRequestHandler<GetTermBrokenRulesQuery, IEnumerable<GetTermBrokenRulesQueryViewModel>>
{
    private readonly IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermBrokenRuleRepository repoBrokenRule;
    private readonly IPresTrustUserContext userContext;

    public GetTermBrokenRulesQueryHandler(
            IMapper mapper,
            IApplicationRepository repoApplication,
            ITermBrokenRuleRepository repoBrokenRule,
            IPresTrustUserContext userContext
            ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoBrokenRule = repoBrokenRule;
        this.userContext = userContext;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<GetTermBrokenRulesQueryViewModel>> Handle(GetTermBrokenRulesQuery request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        userContext.DeriveRole(application.AgencyId);
        bool isApplicantFlow = userContext.Role != Domain.Enums.UserRoleEnum.PROGRAM_ADMIN;

        // get broken rule details
        var brokenRules = await repoBrokenRule.GetBrokenRulesAsync(request.ApplicationId);
        if (isApplicantFlow)
        {
            brokenRules = (List<FarmBrokenRuleEntity>)brokenRules.Where(o => o.IsApplicantFlow).ToList();
        }

        var result = mapper.Map<IEnumerable<FarmBrokenRuleEntity>, IEnumerable<GetTermBrokenRulesQueryViewModel>>(brokenRules);

        return result;
    }
}
