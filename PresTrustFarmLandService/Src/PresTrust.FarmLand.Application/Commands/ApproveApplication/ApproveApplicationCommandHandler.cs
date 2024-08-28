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

        var docBrokenrules = await TermAppAdminDeedDetailsDocs(application.Id, application.Status, (int)ApplicationSectionEnum.ADMIN_DEED_DETAILS);
        if (docBrokenrules.Count > 0)
        {
            brokenRules.AddRange(docBrokenrules);
        }

        if (brokenRules != null && brokenRules.Any())
        {
            result.BrokenRules = mapper.Map<IEnumerable<TermBrokenRuleEntity>, IEnumerable<TermBrokenRuleViewModel>>(brokenRules);
            return result;
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
            SectionId = (int)ApplicationSectionEnum.ADMIN_DETAILS,
            Message = "All required fields on ADMIN_DETAILS tab have not been filled.",

        });

        statusChangeRules.Add(new TermBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = (int)ApplicationSectionEnum.ADMIN_DEED_DETAILS,
            Message = "All required fields on ADMIN_DEED_DETAILS tab have not been filled.",
        });

        return statusChangeRules;
    }
    private async Task<List<TermBrokenRuleEntity>> TermAppAdminDeedDetailsDocs(int applicationId, ApplicationStatusEnum applicationStatus, int sectionId)
    {

        var documents = await repoOtherDocs.GetTermDocumentsAsync(applicationId, sectionId);

        List<TermBrokenRuleEntity> docBrokenrules = new List<TermBrokenRuleEntity>();
        if (applicationStatus == ApplicationStatusEnum.PETITION_APPROVED)
        {
            if (documents.Where(o => o.DocumentTypeId == (int)ApplicationDocumentTypeEnum.TRUE_COPY_OF_DEED).Count() == 0)
            {
                docBrokenrules.Add(new TermBrokenRuleEntity()
                {
                    ApplicationId = applicationId,
                    SectionId = (int)ApplicationSectionEnum.ADMIN_DEED_DETAILS,
                    Message = "True Copy Of Deed required document on Deed Details tab have not been Uploaded."
                });
            }
            if (documents.Where(o => o.DocumentTypeId == (int)ApplicationDocumentTypeEnum.COPY_OF_OWNER_OF_LAST_RECORD_SEARCH).Count() == 0)
            {
                docBrokenrules.Add(new TermBrokenRuleEntity()
                {
                    ApplicationId = applicationId,
                    SectionId = (int)ApplicationSectionEnum.OTHER_DOCUMENTS,
                    Message = "Copy Of Owner required document on Deed Details tab have not been Uploaded.",
                });
            }

        }
        return docBrokenrules;
    }

}
