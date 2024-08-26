using static System.Collections.Specialized.BitVector32;

namespace PresTrust.FarmLand.Application.Commands;

public class ApproveApplicationCommandHandler : BaseHandler, IRequestHandler<ApproveApplicationCommand, ApproveApplicationCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    private readonly ITermOtherDocumentsRepository repoOtherDocs;
    private readonly IEmailTemplateRepository repoEmailTemplate;
    private readonly IEmailManager repoEmailManager;

    public ApproveApplicationCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        ITermBrokenRuleRepository repoBrokenRules,
        ITermOtherDocumentsRepository repoOtherDocs,
        IEmailTemplateRepository repoEmailTemplate,
        IEmailManager repoEmailManager
    ) : base(repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoBrokenRules = repoBrokenRules;
        this.repoOtherDocs = repoOtherDocs;
        this.repoEmailTemplate = repoEmailTemplate;
        this.repoEmailManager = repoEmailManager;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ApproveApplicationCommandViewModel> Handle(ApproveApplicationCommand request, CancellationToken cancellationToken)
    {
        ApproveApplicationCommandViewModel result = new();

        // check if application exists
        var application = await GetIfApplicationExists(request.ApplicationId);

        //update application
        if (application != null)
        {
            application.StatusId = (int)ApplicationStatusEnum.PETITION_APPROVED;
            application.LastUpdatedBy = userContext.Email;
        }

        // check if any broken rules exists, if yes then return
        var brokenRules = (await repoBrokenRules.GetBrokenRulesAsync(application.Id))?.ToList();

        if (brokenRules != null && brokenRules.Any())
        {
            result.BrokenRules = mapper.Map<IEnumerable<TermBrokenRuleEntity>, IEnumerable<TermBrokenRuleViewModel>>(brokenRules);
            return result;
        }

        // check if any broken rules exists, if yes then return
        var hasDeedDetailsDocuments = await TermAppAdminDeedDetailsDocs(application);
        if (hasDeedDetailsDocuments.Count > 0)
        {
            brokenRules.Add(new TermBrokenRuleEntity()
            {
                ApplicationId = application.Id,
                SectionId = (int)ApplicationSectionEnum.TERM_ADMIN_DEED_DETAILS,
                Message = "Required Documents are not uploaded in ADMIN_DEED_DETAILS Tab",
            });
        }

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            // returns broken rules  
            var defaultBrokenRules = ReturnBrokenRulesIfAny(application);
            // save broken rules
            await repoBrokenRules.SaveBrokenRules(defaultBrokenRules);
            await repoApplication.UpdateApplicationStatusAsync(application, ApplicationStatusEnum.PETITION_APPROVED);
            FarmApplicationStatusLogEntity appStatusLog = new()
            {
                ApplicationId = application.Id,
                StatusId = application.StatusId,
                StatusDate = DateTime.Now,
                Notes = string.Empty,
                LastUpdatedBy = application.LastUpdatedBy
            };
            await repoApplication.SaveStatusLogAsync(appStatusLog);
            //Send Email 
            var template = await repoEmailTemplate.GetEmailTemplate(EmailTemplateCodeTypeEnum.CHANGE_STATUS_FROM_REQUESTED_TO_APPROVED.ToString());
            if (template != null)
                await repoEmailManager.SendMail(subject: template.Subject, applicationId: application.Id, applicationName: application.Title, htmlBody: template.Description, agencyId: application.AgencyId, municapality: application.Municipality);

            scope.Complete();
            result.IsSuccess = true;
        }

        return result;
    }

    /// <summary>
    /// Return broken rules in case of any business rule failure
    /// </summary>
    /// <param name="request"></param>
    /// <param name="application"></param>
    /// <returns></returns>
    private List<TermBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmApplicationEntity application)
    {
        List<TermBrokenRuleEntity> statusChangeRules = new List<TermBrokenRuleEntity>();

        // add default broken rule while initiating application flow
        statusChangeRules.Add(new TermBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = (int)ApplicationSectionEnum.TERM_ADMIN_DETAILS,
            Message = "All required fields on ADMIN_DETAILS tab have not been filled.",

        });

        statusChangeRules.Add(new TermBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = (int)ApplicationSectionEnum.TERM_ADMIN_DEED_DETAILS,
            Message = "All required fields on ADMIN_DEED_DETAILS tab have not been filled.",
        });

        return statusChangeRules;
    }

    private async Task<List<TermBrokenRuleEntity>> TermAppAdminDeedDetailsDocs(FarmApplicationEntity application)
    {
        int sectionId = (int)ApplicationSectionEnum.TERM_ADMIN_DEED_DETAILS;
        List<TermBrokenRuleEntity> brokenRules = new List<TermBrokenRuleEntity>();
        var documents = await repoOtherDocs.GetTermDocumentsAsync(application.Id,sectionId);
        TermOtherDocumentsEntity docsCopyOfDeed = default;
        TermOtherDocumentsEntity docsCopyOfOwner = default;

        if (documents != null && documents.Count() > 0)
        {
            docsCopyOfDeed = documents.Where(d => d.DocumentTypeId == (int)ApplicationDocumentTypeEnum.TRUE_COPY_OF_DEED).FirstOrDefault();
            docsCopyOfOwner = documents.Where(d => d.DocumentTypeId == (int)ApplicationDocumentTypeEnum.COPY_OF_OWNER_OF_LAST_RECORD_SEARCH).FirstOrDefault();
        }
        if (application.Status == ApplicationStatusEnum.PETITION_REQUEST)
        {
            if (docsCopyOfDeed == null)
                brokenRules.Add(new TermBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "True Copy Of Deed required document on Deed Details tab have not been Uploaded.",
                    IsApplicantFlow = false
                });

            if (docsCopyOfOwner == null)
                brokenRules.Add(new TermBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Copy Of Owner required document on Deed Details tab have not been Uploaded.",
                    IsApplicantFlow = false
                });
        }
        return brokenRules;
    }


}
