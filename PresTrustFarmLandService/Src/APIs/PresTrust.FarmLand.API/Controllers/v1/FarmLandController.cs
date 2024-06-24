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
    public async Task<ActionResult<GetApplicationDetailsQueryViewModel>> GetApplications([FromBody] GetApplicationDetailsQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("getRoles")]
    [ProducesResponseType(typeof(IEnumerable<FarmRolesViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<FarmRolesViewModel>>> getRoles([FromBody] GetRolesQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("createApplication")]
    [ProducesResponseType(typeof(CreateApplicationCommandViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateApplicationCommandViewModel>> CreateApplication([FromBody] CreateApplicationCommand query)
    {
        return Single(await CommandAsync(query));
    }

    /// <summary>
    /// Get municipal finances
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpPost("getMunicipalFinance")]
    [ProducesResponseType(typeof(GetMunicipalFinanceQueryViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<GetMunicipalFinanceQueryViewModel>> GetMunicipalFinance([FromBody] GetMunicipalFinanceQuery query)
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
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
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
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<int>> SaveMunicipalFinance([FromBody] SaveMunicipalFinanceCommand query)
    {
        return Single(await CommandAsync(query));
    }

    [HttpPost("getFarmList")]
    [ProducesResponseType(typeof(IEnumerable<GetFarmListQueryViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<GetFarmListQueryViewModel>>> GetFarmList([FromBody] GetFarmListQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("getTermFeedbacks")]
    [ProducesResponseType(typeof(IEnumerable<GetTermFeedbacksQueryViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<GetTermFeedbacksQueryViewModel>>> getApplicationFeedbacks([FromBody] GetTermFeedbacksQuery query)
    {
        return Single(await QueryAsync(query));
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("saveTermFeedback")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> SaveApplicationFeedback([FromBody] SaveTermFeedbackCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("saveTermComment")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    
    public async Task<ActionResult<int>> saveTermComment([FromBody] SaveTermCommentCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("deleteTermComment")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    
    public async Task<ActionResult<bool>> deleteTermComment([FromBody] DeleteTermCommentCommand command)
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

   
}
