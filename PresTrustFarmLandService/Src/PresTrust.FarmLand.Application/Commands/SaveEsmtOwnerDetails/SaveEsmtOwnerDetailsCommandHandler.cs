using Azure.Core;
using MediatR;

namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtOwnerDetailsCommandHandler : BaseHandler, IRequestHandler<SaveEsmtOwnerDetailsCommand, int>
{
    private IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private IEsmtOwnerDetailsRepository repoOwner;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    private readonly IOwnerDetailsRepository repoOwnerDetails;

    public SaveEsmtOwnerDetailsCommandHandler(
       IMapper mapper,
       IPresTrustUserContext userContext,
       IOptions<SystemParameterConfiguration> systemParamOptions,
       IApplicationRepository repoApplication,
       IEsmtOwnerDetailsRepository repoOwner,
        ITermBrokenRuleRepository repoBrokenRules,
        IOwnerDetailsRepository repoOwnerDetails
      ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoOwner = repoOwner;
        this.repoBrokenRules = repoBrokenRules;
        this.repoOwnerDetails = repoOwnerDetails;
    }

    public async Task<int> Handle(SaveEsmtOwnerDetailsCommand request, CancellationToken cancellationToken)
    {
        userContext.DeriveUserProfileFromUserId(request.UserId);
        var application = await GetIfApplicationExists(request.ApplicationId);

        var reqEsmtOwner = mapper.Map<SaveEsmtOwnerDetailsCommand, EsmtOwnerDetailsEntity>(request);

        // Check Broken Rules
        var brokenRules = ReturnBrokenRulesIfAny(application, reqEsmtOwner);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            reqEsmtOwner = await repoOwner.SaveOwnerDetailsAsync(reqEsmtOwner);

            // Delete old Broken Rules, if any
            await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, EsmtAppSectionEnum.OWNER_DETAILS);
            
            // Save current Broken Rules, if any
            await repoBrokenRules.SaveBrokenRules(brokenRules);

            
            scope.Complete();
        }

        return reqEsmtOwner.Id;

    }

    private  List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmApplicationEntity application, EsmtOwnerDetailsEntity reqEsmtOwner)
    {
        int sectionId = (int)EsmtAppSectionEnum.OWNER_DETAILS;
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();

        var ownerDetails = repoOwnerDetails.GetOwnerDetailsAsync(application.Id);

        if (ownerDetails.Result.Count() == 0)
        {
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = reqEsmtOwner.ApplicationId,
                SectionId = sectionId,
                Message = "At least One Record Should be filled in Owner Details Tab.",
                IsApplicantFlow = true
            });
        }


        // add based on the empty check conditions
        if (string.IsNullOrEmpty(reqEsmtOwner.FarmName))
            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = reqEsmtOwner.ApplicationId,
                SectionId = sectionId,
                Message = "Farm Name required field on Owner Details tab have not been filled.",
                IsApplicantFlow = true
            });

        return brokenRules;

    }
}
