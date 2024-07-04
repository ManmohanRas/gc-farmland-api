using PresTrust.FarmLand.Domain;

namespace PresTrust.FarmLand.Application.Commands;

public class RequestApplicationCommandHandler : BaseHandler, IRequestHandler<RequestApplicationCommand, RequestApplicationCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermBrokenRuleRepository repoBrokenRules;

    public RequestApplicationCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        ITermBrokenRuleRepository repoBrokenRules
    ) : base(repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoBrokenRules = repoBrokenRules;
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

        //update application
        if (application != null)
        {
            application.StatusId = (int)ApplicationStatusEnum.REQUESTED;
            application.LastUpdatedBy = userContext.Email;
        }

        // check if any broken rules exists, if yes then return
        var brokenRules = (await repoBrokenRules.GetBrokenRulesAsync(application.Id))?.ToList();

        if (brokenRules != null && brokenRules.Any())
        {
            result.BrokenRules = mapper.Map<IEnumerable<TermBrokenRuleEntity>, IEnumerable<TermBrokenRuleViewModel>>(brokenRules);
            return result;
        }

        //var otherdocRules = await CheckApplicationOtherDocs(application.Id, application.ApplicationTypeId, (int)ApplicationSectionEnum.OTHER_DOCUMENTS);
        //if (otherdocRules.Count > 0)
        //{
        //    brokenRules.AddRange(otherdocRules);
        //}

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            // returns broken rules  
            var defaultBrokenRules = ReturnBrokenRulesIfAny(application);
            // save broken rules
            await repoBrokenRules.SaveBrokenRules(defaultBrokenRules);
            await repoApplication.SaveApplicationWorkflowStatusAsync(application);
            FarmApplicationStatusLogEntity appStatusLog = new()
            {
                ApplicationId = application.Id,
                StatusId = application.StatusId,
                StatusDate = DateTime.Now,
                Notes = string.Empty,
                LastUpdatedBy = application.LastUpdatedBy
            };
            await repoApplication.SaveStatusLogAsync(appStatusLog);

            scope.Complete();
            result.IsSuccess = true;
        }

        return result;
    }

    //private async Task<List<TermBrokenRuleEntity>> CheckApplicationOtherDocs(int applicationId, int sectionId)
    //{
    //    var documents = await repoApplicationDocument.GetApplicationDocumentsAsync(applicationId, sectionId);

    //    List<TermBrokenRuleEntity> otherdocRules = new List<TermBrokenRuleEntity>();
    //    if (applcation.Status == ApplicationStatusEnum.REQUESTED)
    //    {
    //        if (documents.Where(o => o.DocumentTypeId == (int)ApplicationDocumentTypeEnum.CADB_PETITION).Count() == 0)
    //        {
    //            otherdocRules.Add(new TermBrokenRuleEntity()
    //            {
    //                ApplicationId = applicationId,
    //                SectionId = (int)ApplicationSectionEnum.OTHER_DOCUMENTS,
    //                Message = "APPLICATION_CHECKLIST document is not uploaded in OtherDocuments Tab"
    //            });
    //        }
    //        if (documents.Where(o => o.DocumentTypeId == (int)ApplicationDocumentTypeEnum.DEED).Count() == 0)
    //        {
    //            otherdocRules.Add(new TermBrokenRuleEntity()
    //            {
    //                ApplicationId = applicationId,
    //                SectionId = (int)ApplicationSectionEnum.OTHER_DOCUMENTS,
    //                Message = "PUBLIC_HEARING_CERTIFICATE document is not uploaded in OtherDocuments Tab"
    //            });
    //        }
    //        if (documents.Where(o => o.DocumentTypeId == (int)ApplicationDocumentTypeEnum.TAX_MAP).Count() == 0)
    //        {
    //            otherdocRules.Add(new TermBrokenRuleEntity()
    //            {
    //                ApplicationId = applicationId,
    //                SectionId = (int)ApplicationSectionEnum.OTHER_DOCUMENTS,
    //                Message = "MINUTES_FROM_PUBLIC_HEARING document is not uploaded in OtherDocuments Tab"
    //            });
    //        }
    //    }
    //    return otherdocRules;
    //}

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
            SectionId = (int)ApplicationSectionEnum.LOCATION,
            Message = "All required fields on LOCATION tab have not been filled.",
            
        });

        statusChangeRules.Add(new TermBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = (int)ApplicationSectionEnum.OWNER_DETAILS,
            Message = "All required fields on OWNER_DETAILS tab have not been filled.",
        });

        statusChangeRules.Add(new TermBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = (int)ApplicationSectionEnum.SIGNATORY,
            Message = "All required fields on OWNER_DETAILS tab have not been filled.",
        });

        return statusChangeRules;
    }

}
