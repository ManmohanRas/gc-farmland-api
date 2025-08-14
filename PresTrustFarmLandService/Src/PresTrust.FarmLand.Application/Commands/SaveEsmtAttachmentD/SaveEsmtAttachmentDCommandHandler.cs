namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAttachmentDCommandHandler : BaseHandler, IRequestHandler<SaveEsmtAttachmentDCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IPresTrustUserContext userContext;
        private readonly SystemParameterConfiguration systemParamOptions;
        private readonly IApplicationRepository repoApplication;
        private IEsmtAppAttachmentDRepository repoEsmtAttachment;
        private ITermBrokenRuleRepository repoBrokenRules;
    public SaveEsmtAttachmentDCommandHandler
    (
    IMapper mapper,
    IPresTrustUserContext userContext,
    IOptions<SystemParameterConfiguration> systemParamOptions,
    IApplicationRepository repoApplication,
    IEsmtAppAttachmentDRepository repoEsmtAttachment,
    ITermBrokenRuleRepository repoBrokenRules
        ) : base(repoApplication: repoApplication)
        {
            this.mapper = mapper;
            this.userContext = userContext;
            this.systemParamOptions = systemParamOptions.Value;
            this.repoApplication = repoApplication;
            this.repoEsmtAttachment = repoEsmtAttachment;
            this.repoBrokenRules = repoBrokenRules;
        }

        public async Task<Unit> Handle(SaveEsmtAttachmentDCommand request, CancellationToken cancellationToken)
        {
        userContext.DeriveUserProfileFromUserId(request.UserId);
        var application = await repoApplication.GetApplicationAsync(request.ApplicationId);

            //int attachmentId = 0;
            var brokenRules = ReturnBrokenRulesIfAny(application);

            using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
            {
                foreach (var attachment in request.AttachmentDetails)
                {
                    var entity = mapper.Map<SaveEsmtAttachmentDViewModel, FarmEsmtAttachmentDSourseEntity>(attachment);
                    entity.ApplicationId = request.ApplicationId;
                    entity.LastUpdatedBy = userContext.Name;
                    await this.repoEsmtAttachment.SaveAsync(entity);

                }
            await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, EsmtAppSectionEnum.EQUINE_USES);
            await repoBrokenRules.SaveBrokenRules(brokenRules);


            scope.Complete();
            }
            return Unit.Value;

        }

    private List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmApplicationEntity application)
    {
        int sectionId = (int)EsmtAppSectionEnum.EQUINE_USES;
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();
        var attacmentDetails = this.repoEsmtAttachment.GetAttachmentSourcesAsync(application.Id);

        if (attacmentDetails.Result.Count() == 0)

            brokenRules.Add(new FarmBrokenRuleEntity()
            {
                ApplicationId = application.Id,
                SectionId = sectionId,
                Message = "Attachment D is mandatory.",
                IsApplicantFlow = true
            });

        return brokenRules;
    }
}

  
