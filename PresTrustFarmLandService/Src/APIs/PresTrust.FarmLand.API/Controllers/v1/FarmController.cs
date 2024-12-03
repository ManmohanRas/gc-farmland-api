namespace PresTrust.FarmLand.API.Controllers.v1;

[Authorize()]
[Route("api/v1/farm")]
[ApiController]
public class FarmController : ApiBaseController
{
    public FarmController(IMediator mediator) : base(mediator) { }


    [HttpPost("getApplications")]
    [ProducesResponseType(typeof(List<GetApplicationsQueryViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<List<GetApplicationsQueryViewModel>>> GetApplications([FromBody] GetApplicationsQuery query)
    {
        return Single(await QueryAsync(query));
    }


    [HttpPost("getApplicationStatusLog")]
    [ProducesResponseType(typeof(IEnumerable<GetApplicationStatusLogQueryViewModel>), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<IEnumerable<GetApplicationStatusLogQueryViewModel>>> GetApplicationStatusLog([FromBody] GetApplicationStatusLogQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("createTermApplication")]
    [ProducesResponseType(typeof(CreateTermApplicationCommandViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateTermApplicationCommandViewModel>> CreateTermApplication([FromBody] CreateTermApplicationCommand query)
    {
        return Single(await CommandAsync(query));
    }

    [HttpPost("createEsmtApplication")]
    [ProducesResponseType(typeof(CreateEsmtApplicationCommandViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateEsmtApplicationCommandViewModel>> CreateEsmtApplication([FromBody] CreateEsmtApplicationCommand query)
    {
        return Single(await CommandAsync(query));
    }

    [HttpPost("getRoles")]
    [ProducesResponseType(typeof(IEnumerable<FarmRolesViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<FarmRolesViewModel>>> GetRoles([FromBody] GetRolesQuery query)
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


    [HttpPost("getOwnerDetails")]
    [ProducesResponseType(typeof(GetOwnerDetailsQueryViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetOwnerDetailsQueryViewModel>> GetOwnerDetails([FromBody] GetOwnerDetailsQuery query)
    {
        return Single(await QueryAsync(query));
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

    [HttpPost("getFeedbacks")]
    [ProducesResponseType(typeof(IEnumerable<GetFeedbacksQueryViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<GetFeedbacksQueryViewModel>>> getFeedbacks([FromBody] GetFeedbacksQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("saveFeedback")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> SaveApplicationFeedback([FromBody] SaveFeedbackCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("markFeedbacksAsRead")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> MarkApplicationFeedbacksAsRead([FromBody] MarkFeedbacksAsReadCommand command)
    {
        return Single(await CommandAsync(command));
    }


    [HttpPost("requestForApplicationCorrection")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> RequestForApplicationCorrectionCommand([FromBody] RequestForApplicationCorrectionCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("responseToRequestForApplicationCorrection")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> ResponseToRequestForApplicationCorrectionCommand([FromBody] ResponseToRequestForApplicationCorrectionCommand command)
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

    [HttpPost("getComments")]
    [ProducesResponseType(typeof(IEnumerable<GetCommentsQueryViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<GetCommentsQueryViewModel>>> getComments([FromBody] GetCommentsQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("saveComment")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<int>> saveComment([FromBody] SaveCommentCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("deleteComment")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<bool>> deleteComment([FromBody] DeleteCommentCommand command)
    {
        return Single(await CommandAsync(command));

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

    

    [HttpPost("saveApplicationDocumentChecklist")]
    [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<Unit>> SaveApplicationDocumentChecklist([FromBody] SaveAppDocumentChecklistCommand command)
    {
        return Single(await CommandAsync(command));
    }


    [HttpPost("getDocuments")]
    [ProducesResponseType(typeof(IEnumerable<DocumentTypeViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<DocumentTypeViewModel>>> GetDocuments([FromBody] GetDocumentsBySectionQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("getApplicationDocumentChecklist")]
    [ProducesResponseType(typeof(IEnumerable<DocumentChecklistViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<DocumentChecklistViewModel>>> getApplicationDocumentChecklist([FromBody] GetDocumentChecklistQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("saveDocument")]
    [ProducesResponseType(typeof(SaveAppDocumentCommandViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<SaveAppDocumentCommandViewModel>> SaveDocument([FromBody] SaveAppDocumentCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("deleteDocument")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> DeleteDocument([FromBody] DeleteAppDocumentCommand command)
    {
        return Single(await CommandAsync(command));
    }

    //Application Signatory 


    [HttpPost("getBrokenRules")]
    [ProducesResponseType(typeof(IEnumerable<GetBrokenRulesQueryViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<GetBrokenRulesQueryViewModel>>> GetBrokenRules([FromBody] GetBrokenRulesQuery query)
    {
        return Single(await QueryAsync(query));
    }



    [HttpPost("getMunicipalFinance")]
    [ProducesResponseType(typeof(GetMunicipalFinanceQueryViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetMunicipalFinanceQueryViewModel>> GetMunicipalFinance([FromBody] GetMunicipalFinanceQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("getContacts")]
    [ProducesResponseType(typeof(IEnumerable<GetAppAdminContactsQueryViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<GetAppAdminContactsQueryViewModel>>> GetContacts([FromBody] GetAppAdminContactsQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("saveContacts")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> SaveContacts([FromBody] SaveAppAdminContactsCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("deleteContact")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> DeleteContact([FromBody] DeleteTermAppAdminContactsCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("getFarmList")]
    [ProducesResponseType(typeof(IEnumerable<GetFarmListQueryViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<GetFarmListQueryViewModel>>> GetFarmList([FromBody] GetFarmListQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("saveFarmList")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> SaveFarmList([FromBody] SaveFarmListCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("getFarmBlockLots")]
    [ProducesResponseType(typeof(IEnumerable<GetFarmBlockLotQueryViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<GetFarmBlockLotQueryViewModel>>> GetFarmBlockLots([FromBody] GetFarmBlockLotQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("saveFarmBlockLot")]
    [ProducesResponseType(typeof(SaveFarmBlockLotCommandViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<SaveFarmBlockLotCommandViewModel>> SaveFarmBlockLot([FromBody] SaveFarmBlockLotCommand command)
    {
        return Single(await CommandAsync(command));
    }


    [HttpPost("getLocationDetails")]
    [ProducesResponseType(typeof(GetLocationDetailsQueryViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetLocationDetailsQueryViewModel>> GetLocationDetails([FromBody] GetLocationDetailsQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("saveLocationDetails")]
    [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Unit>> SaveLocationDetails([FromBody] SaveLocationDetailsCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("resolveParcelWarning")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> ResolveParcelWarning([FromBody] ResolveParcelWarningCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("getParcelHistory")]
    [ProducesResponseType(typeof(List<GetParcelHistoryQueryViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<List<GetParcelHistoryQueryViewModel>>> GetParcelHistory([FromBody] GetParcelHistoryQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("deleteBlockLot")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> DeleteBlockLot([FromBody] DeleteBlockLotCommand command)
    {
        return Single(await CommandAsync(command));
    }

    //TERM WORK FLOWS

    [HttpPost("requestApplication")]
    [ProducesResponseType(typeof(RequestApplicationCommandViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<RequestApplicationCommandViewModel>> RequestApplication([FromBody] RequestApplicationCommand query)
    {
        return Single(await CommandAsync(query));
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

    [HttpPost("expireApplication")]
    [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Unit>> expireApplication([FromBody] ExpireApplicationCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("enableSADC")]
    [ProducesResponseType(typeof(EnableSadcCommandViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Unit>> EnableSADC([FromBody] EnableSadcCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("getFarmReSale")]
    [ProducesResponseType(typeof(IEnumerable<GetFarmReSaleQueryViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<GetFarmReSaleQueryViewModel>>> GetFarmReSale([FromBody] GetFarmReSaleQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("saveFarmReSale")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> SaveFarmReSale([FromBody] SaveFarmReSaleCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("deleteFarmReSale")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> DeleteFarmReSale([FromBody] DeleteFarmReSaleCommand command)
    {
        return Single(await CommandAsync(command));
    }

}

