using static System.Collections.Specialized.BitVector32;

namespace PresTrust.FarmLand.Application.Commands;

public class RequestApplicationCommandHandler : BaseHandler, IRequestHandler<RequestApplicationCommand, RequestApplicationCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    private readonly ITermOtherDocumentsRepository repoOtherDocs;
    private readonly IEmailTemplateRepository repoEmailTemplate;
    private readonly IEmailManager repoEmailManager;

    public RequestApplicationCommandHandler
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
    public async Task<RequestApplicationCommandViewModel> Handle(RequestApplicationCommand request, CancellationToken cancellationToken)
    {
        RequestApplicationCommandViewModel result = new();

        // check if application exists
        var application = await GetIfApplicationExists(request.ApplicationId);
        AuthorizationCheck(application);


        //update application
        if (application != null)
        {
            application.StatusId = (int)TermAppStatusEnum.PETITION_REQUEST;
            application.LastUpdatedBy = userContext.Email;
        }

        // check if any broken rules exists, if yes then return
        var brokenRules = (await repoBrokenRules.GetBrokenRulesAsync(application.Id));

     

        var otherdocRules = await CheckApplicationOtherDocs(application.Id, application.Status, (int)TermAppSectionEnum.OTHER_DOCUMENTS);
        if (otherdocRules.Count > 0)
        {
            brokenRules.AddRange(otherdocRules);
        }

        if (brokenRules != null && brokenRules.Any())
        {
            result.BrokenRules = mapper.Map<IEnumerable<FarmBrokenRuleEntity>, IEnumerable<BrokenRuleViewModel>>(brokenRules);
            return result;
        }


        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            // returns broken rules  
            var defaultBrokenRules = ReturnBrokenRulesIfAny(application);
            // save broken rules
            await repoBrokenRules.SaveBrokenRules(defaultBrokenRules);
            await repoApplication.UpdateApplicationStatusAsync(application, TermAppStatusEnum.PETITION_REQUEST);
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
            var template = await repoEmailTemplate.GetEmailTemplate(EmailTemplateCodeTypeEnum.CHANGE_STATUS_FROM_DRAFT_TO_REQUESTED.ToString());
            if (template != null)
                await repoEmailManager.SendMail(subject: template.Subject, applicationId: application.Id, applicationName: application.Title, htmlBody: template.Description, agencyId: application.AgencyId);
            scope.Complete();
            result.IsSuccess = true;
        }

        return result;
    }
    private void AuthorizationCheck(FarmApplicationEntity application)
    {
        // security
        userContext.DeriveRole(application.AgencyId);
        IsAuthorizedOperation(userRole: userContext.Role, application: application, operation: TermUserPermissionEnum.SUBMIT_APPLICATION);
    }
    private async Task<List<FarmBrokenRuleEntity>> CheckApplicationOtherDocs(int applicationId, TermAppStatusEnum applicationStatus, int sectionId)
    {

        var documents = await repoOtherDocs.GetTermDocumentsAsync(applicationId, sectionId);

        List<FarmBrokenRuleEntity> otherdocRules = new List<FarmBrokenRuleEntity>();
        if (applicationStatus == TermAppStatusEnum.PETITION_REQUEST)
        {
            if (documents.Where(o => o.DocumentTypeId == (int)ApplicationDocumentTypeEnum.CADB_PETITION).Count() == 0)
            {
                otherdocRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = applicationId,
                    SectionId = (int)TermAppSectionEnum.OTHER_DOCUMENTS,
                    Message = "CADB_PETITION document is not uploaded in Other Documents Tab"
                });
            }
            if (documents.Where(o => o.DocumentTypeId == (int)ApplicationDocumentTypeEnum.DEED).Count() == 0)
            {
                otherdocRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = applicationId,
                    SectionId = (int)TermAppSectionEnum.OTHER_DOCUMENTS,
                    Message = "DEED document is not uploaded in Other Documents Tab"
                });
            }
            if (documents.Where(o => o.DocumentTypeId == (int)ApplicationDocumentTypeEnum.TAX_MAP).Count() == 0)
            {
                otherdocRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = applicationId,
                    SectionId = (int)TermAppSectionEnum.OTHER_DOCUMENTS,
                    Message = "TAX_MAP document is not uploaded in Other Documents Tab"
                });
            }
            if (documents.Where(o => o.DocumentTypeId == (int)ApplicationDocumentTypeEnum.LANDOWNER_SIGNATURE).Count() == 0)
            {
                otherdocRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = applicationId,
                    SectionId = (int)TermAppSectionEnum.OTHER_DOCUMENTS,
                    Message = "Landowner Signature document is not uploaded in Other Documents Tab"
                });
            }

        }
        return otherdocRules;
    }
    // <summary>
    /// Return broken rules in case of any business rule failure
    /// </summary>
    /// <param name="request"></param>
    /// <param name="application"></param>
    /// <returns></returns>
    private List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmApplicationEntity application)
    {
        List<FarmBrokenRuleEntity> statusChangeRules = new List<FarmBrokenRuleEntity>();

        // add default broken rule while initiating application flow
        statusChangeRules.Add(new FarmBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = (int)TermAppSectionEnum.ADMIN_DETAILS,
            Message = "All required fields on ADMIN_DETAILS tab have not been filled.",

        });

        statusChangeRules.Add(new FarmBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = (int)TermAppSectionEnum.ADMIN_DEED_DETAILS,
            Message = "All required fields on ADMIN_DEED_DETAILS tab have not been filled.",
        });

        statusChangeRules.Add(new FarmBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = (int)TermAppSectionEnum.ADMIN_DOCUMENT_CHECKLIST,
            Message = "All documents need to be marked as Approved in the Other Documents section of the Document Checklist",
            IsApplicantFlow = false
        });
        return statusChangeRules;
    }
}
