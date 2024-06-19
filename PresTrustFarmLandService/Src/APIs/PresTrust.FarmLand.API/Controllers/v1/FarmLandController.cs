using PresTrust.FarmLand.Application.Commands;

namespace PresTrust.FarmLand.API.Controllers.v1
{
    [Route("api/v1/farm")]
    [ApiController]
    public class FarmLandController: ApiBaseController
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
        public async Task<ActionResult<IEnumerable<FarmRolesViewModel>>> getRoles([FromBody] GetRolesQuery query)
         {
            return Single(await QueryAsync(query));
        }

        [HttpPost("getFarmList")]
        [ProducesResponseType(typeof(IEnumerable<GetFarmListQueryViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetFarmListQueryViewModel>>> GetFarmList([FromBody] GetFarmListQuery query)
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
        public async Task<ActionResult<CreateApplicationCommandViewModel>> GetFarmList([FromBody] CreateApplicationCommand query)
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
    }
}
