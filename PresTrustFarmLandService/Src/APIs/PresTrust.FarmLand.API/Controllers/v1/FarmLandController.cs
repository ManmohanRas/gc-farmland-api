using PresTrust.FarmLand.Domain.CommonViewModels;

namespace PresTrust.FarmLand.API.Controllers.v1;

[Authorize()]
[Route("api/v1/farm")]
[ApiController]
public class FarmLandController : ApiBaseController
{
    public FarmLandController(IMediator mediator) : base(mediator) { }

   

        [HttpPost("getApplications")]
        [ProducesResponseType(typeof(List<GetApplicationsQueryViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<GetApplicationsQueryViewModel>>> GetApplications([FromBody] GetApplicationsQuery query)
        {
            return Single(await QueryAsync(query));
        }

        [HttpPost("getRoles")]
        [ProducesResponseType(typeof(IEnumerable<FarmRolesViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<FarmRolesViewModel>>> GetRoles([FromBody] GetRolesQuery query)
        {
            return Single(await QueryAsync(query));
        }

        [HttpPost("getFarmList")]
        [ProducesResponseType(typeof(IEnumerable<GetFarmListQueryViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetFarmListQueryViewModel>>> GetFarmList([FromBody] GetFarmListQuery query)
        {
            return Single(await QueryAsync(query));
        }
        [HttpPost("getTermFeedbacks")]
        [ProducesResponseType(typeof(IEnumerable<GetTermFeedbacksQueryViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetTermFeedbacksQueryViewModel>>> GetApplicationFeedbacks([FromBody] GetTermFeedbacksQuery query)
        {
            return Single(await QueryAsync(query));
        }

        [HttpPost("getOwnerDetails")]
        [ProducesResponseType(typeof(GetOwnerDetailsQueryViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOwnerDetailsQueryViewModel>> GetOwnerDetails([FromBody] GetOwnerDetailsQuery query)
        {
            return Single(await QueryAsync(query));
        }

        [HttpPost("getSiteCharacteristics")]
        [ProducesResponseType(typeof(GetSiteCharacteristicsQueryViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSiteCharacteristicsQueryViewModel>> GetSiteCharacteristics([FromBody] GetSiteCharacteristicsQuery query)
        {
            return Single(await QueryAsync(query));
        }


    /// <summary>
    /// Assign Application Users like Primary Contact, Applicant Contractor
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
        [HttpPost("saveRoles")]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> AssignApplicationUsers([FromBody] AssignRolesCommand command)
        {
            return Single(await CommandAsync(command));
        }

        [HttpPost("createApplication")]
        [ProducesResponseType(typeof(CreateApplicationCommandViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateApplicationCommandViewModel>> CreateApplication([FromBody] CreateApplicationCommand query)
        {
            return Single(await CommandAsync(query));
        }

        [HttpPost("saveTermFeedback")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> SaveApplicationFeedback([FromBody] SaveTermFeedbackCommand command)
        {
            return Single(await CommandAsync(command));
        }

        [HttpPost("markTermFeedbacksAsRead")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> MarkApplicationFeedbacksAsRead([FromBody] MarkTermFeedbacksAsReadCommand command)
        {
            return Single(await CommandAsync(command));
        }


        [HttpPost("requestForApplicationCorrectionTerm")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> RequestForApplicationCorrectionCommand([FromBody] RequestForApplicationCorrectionCommand command)
        {
            return Single(await CommandAsync(command));
        }

        [HttpPost("responseToRequestForApplicationCorrectionTerm")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> ResponseToRequestForApplicationCorrectionCommand([FromBody] ResponseToRequestForApplicationCorrectionCommand command)
        {
            return Single(await CommandAsync(command));
        }


        [HttpPost("SaveOwnerDetails")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> SaveOwnerDetails([FromBody] SaveOwnerDetailsCommand command)
        {
            return Single(await CommandAsync(command));
        }

        [HttpPost("deleteOwnerDetails")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteOwnerDetails([FromBody] DeleteOwnerDetailsCommand command)
        {
            return Single(await CommandAsync(command));
        }

    /// <summary>
    /// Get County Users 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpPost("getCountyUsers")]
    [ProducesResponseType(typeof(IEnumerable<PresTrustUserEntity>), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<IEnumerable<PresTrustUserEntity>>> GetCountyUsers([FromBody] GetCountyUsersQuery query)
    {
        return Single(await QueryAsync(query));
    }
    /// <summary>
    /// Delete County User Role.
    /// </summary>
    /// <param name="command"> Query Command.</param>
    /// <returns></returns>
    /// 
    [HttpPost("deleteCountyUserRole")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<bool>> DeleteCountyUserRole([FromBody] DeleteCountyUserRoleCommand command)
    {
        return Single(await CommandAsync(command));
    }
    /// <summary>
    /// County User Role Change Request.
    /// </summary>
    /// <param name="command"> Query Command.</param>
    /// <returns></returns>
    /// 
    [HttpPost("countyUserRoleChangeRequest")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<bool>> CountyUserRoleChangeRequest([FromBody] CountyUserRoleChangeRequestCommand command)
    {
        return Single(await CommandAsync(command));
    }

    /// <summary>
    /// Get Municipal Users 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpPost("getMunicipalUsers")]
    [ProducesResponseType(typeof(IEnumerable<PresTrustUserEntity>), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<IEnumerable<PresTrustUserEntity>>> GetMunicipalUsers([FromBody] GetMunicipalUsersQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("getApplicationDetails")]
    [ProducesResponseType(typeof(GetApplicationDetailsQueryViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetApplicationDetailsQueryViewModel>> GetApplicationDetails([FromBody] GetApplicationDetailsQuery query)
    {
        return Single(await QueryAsync(query));
    }

    /// <summary>
    /// Save Municipal TrustFund Permitted Uses
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("saveMunicipalTrustFundPermittedUses")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> SaveMunicipalTrustFundPermittedUses([FromBody] SaveMunicipalTrustFundPermittedUsesCommand query)
    {
        return Single(await CommandAsync(query));
    }

    /// <summary>
    /// Save Municipal Finance
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("saveMunicipalFinance")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> SaveMunicipalFinance([FromBody] SaveMunicipalFinanceCommand query)
    {
        return Single(await CommandAsync(query));
    }

    [HttpPost("getTermComments")]
    [ProducesResponseType(typeof(IEnumerable<GetTermCommentsQueryViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<GetTermCommentsQueryViewModel>>> getTermComments([FromBody] GetTermCommentsQuery query)
    {
        return Single(await QueryAsync(query));
    }

    /// <summary>
    /// Delete Municipal User Role.
    /// </summary>
    /// <param name="command"> Query Command.</param>
    /// <returns></returns>
    /// 
    [HttpPost("deleteMunicipalUserRole")]
    [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> DeleteMunicipalUserRole([FromBody] DeleteMunicipalUserRoleCommand command)
    {
        return Single(await CommandAsync(command));
    }
    

    /// <summary>
    /// Municipal User Role Change Request.
    /// </summary>
    /// <param name="command"> Query Command.</param>
    /// <returns></returns>
    /// 
    [HttpPost("MunicipalUserRoleChangeRequest")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> MunicipalUserRoleChangeRequest([FromBody] MunicipalUserRoleChangeRequestCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("saveTermComment")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    
    public async Task<ActionResult<int>> saveTermComment([FromBody] SaveTermCommentCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("saveApplicationDocumentChecklist")]
    [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<Unit>> SaveApplicationDocumentChecklist([FromBody] SaveTermAppDocumentChecklistCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("deleteTermComment")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    
    public async Task<ActionResult<bool>> deleteTermComment([FromBody] DeleteTermCommentCommand command)
    {
        return Single(await CommandAsync(command));

    }

    [HttpPost("saveSiteCharacteristics")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> SaveSiteCharacteristics([FromBody] SaveSiteCharacteristicsCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("requestApplication")]
    [ProducesResponseType(typeof(RequestApplicationCommandViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<RequestApplicationCommandViewModel>> RequestApplication([FromBody] RequestApplicationCommand query)
    {
        return Single(await CommandAsync(query));
    }


    [HttpPost("getTermDocuments")]
    [ProducesResponseType(typeof(IEnumerable<TermDocumentTypeViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<TermDocumentTypeViewModel>>> GetTermDocuments([FromBody] GetTermDocumentsBySectionQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("getApplicationDocumentChecklist")]
    [ProducesResponseType(typeof(IEnumerable<TermDocumentChecklistViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<TermDocumentChecklistViewModel>>> getApplicationDocumentChecklist([FromBody] GetTermDocumentChecklistQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("saveTermDocument")]
    [ProducesResponseType(typeof(SaveTermAppDocumentCommandViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<SaveTermAppDocumentCommandViewModel>> SaveTermDocument([FromBody] SaveTermAppDocumentCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("deleteTermDocument")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> DeleteTermDocument([FromBody] DeleteTermAppDocumentCommand command)
    {
        return Single(await CommandAsync(command));
    }
    
        //Application Signatory 

        [HttpPost("getTermAppSignatoryDetails")]
        [ProducesResponseType(typeof(GetTermAppSignatoryQueryViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTermAppSignatoryQueryViewModel>> GetTermAppSignatoryDetails([FromBody] GetTermAppSignatoryQuery query)
         {
        return Single(await QueryAsync(query));
        }
   
    

        [HttpPost("saveTermAppSignatoryDetails")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> SaveTermAppSignatoryDetails([FromBody] SaveTermAppSignatoryCommand command)
        {
            return Single(await CommandAsync(command));
        }


        [HttpPost("getBrokenRules")]
        [ProducesResponseType(typeof(IEnumerable<GetTermBrokenRulesQueryViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetTermBrokenRulesQueryViewModel>>> GetTermBrokenRules([FromBody] GetTermBrokenRulesQuery query)
        {
            return Single(await QueryAsync(query));
        }


   
       [HttpPost("getMunicipalFinance")]
       [ProducesResponseType(typeof(GetMunicipalFinanceQueryViewModel), (int)HttpStatusCode.OK)]
       public async Task<ActionResult<GetMunicipalFinanceQueryViewModel>> GetMunicipalFinance([FromBody] GetMunicipalFinanceQuery query)
       {
           return Single(await QueryAsync(query));
       }

       [HttpPost("approveApplication")]
       [ProducesResponseType(typeof(ApproveApplicationCommandViewModel), (int)HttpStatusCode.OK)]
       public async Task<ActionResult<ApproveApplicationCommandViewModel>> ApproveApplication([FromBody] ApproveApplicationCommand command)
       {
           return Single(await CommandAsync(command));
       }


       [HttpPost("rejectApplication")]
       [ProducesResponseType(typeof(RejectApplicationCommandViewModel), (int)HttpStatusCode.OK)]
       public async Task<ActionResult<Unit>> rejectApplication([FromBody] RejectApplicationCommand command)
       {
           return Single(await CommandAsync(command));
       }

       [HttpPost("withdrawApplication")]
       [ProducesResponseType(typeof(WithdrawApplicationCommandViewModel), (int)HttpStatusCode.OK)]
       public async Task<ActionResult<Unit>> WithdrawApplication([FromBody] WithdrawApplicationCommand command)
       {
           return Single(await CommandAsync(command)); 
       }

       [HttpPost("approveAggrement")]
       [ProducesResponseType(typeof(ApproveAggrementCommandViewmodel), (int)HttpStatusCode.OK)]
       public async Task<ActionResult<ApproveAggrementCommandViewmodel>> ApproveAggrement([FromBody] ApproveAggrementCommand command)
       {
           return Single(await CommandAsync(command));
       }

       [HttpPost("activeApplication")]
       [ProducesResponseType(typeof(ActiveApplicationCommandViewModel), (int)HttpStatusCode.OK)]
       public async Task<ActionResult<ActiveApplicationCommandViewModel>> ActiveApplication([FromBody] ActiveApplicationCommand command)
       {
           return Single(await CommandAsync(command));
       }

       [HttpPost("getApplicationSignatoryDetails")]
       [ProducesResponseType(typeof(GetTermAppSignatoryQueryViewModel), (int)HttpStatusCode.OK)]
       public async Task<ActionResult<GetTermAppSignatoryQueryViewModel>> GetApplicationSignatoryDetails([FromBody] GetTermAppSignatoryQuery query)
       {
           return Single(await QueryAsync(query));
       }

       [HttpPost("saveApplicationSignatoryDetails")]
       [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
       public async Task<ActionResult<int>> SaveApplicationSignatoryDetails([FromBody] SaveTermAppSignatoryCommand command)
       {
           return Single(await CommandAsync(command));
       }
    
       [HttpPost("expireApplication")]
       [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
       public async Task<ActionResult<Unit>> expireApplication([FromBody] ExpireApplicationCommand command)
       {
           return Single(await CommandAsync(command));
       }

    [HttpPost("getContacts")]
    [ProducesResponseType(typeof(IEnumerable<GetTermAppAdminContactsQueryViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<GetTermAppAdminContactsQueryViewModel>>> GetContacts([FromBody] GetTermAppAdminContactsQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("saveContacts")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> SaveContacts([FromBody] SaveTermAppAdminContactsCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("deleteContact")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> DeleteContact([FromBody] DeleteTermAppAdminContactsCommand command)
    {
        return Single(await CommandAsync(command));
    }

        [HttpPost("saveFarmList")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> SaveFarmList([FromBody] SaveFarmListCommand command)
        {
            return Single(await CommandAsync(command));
        }
}

