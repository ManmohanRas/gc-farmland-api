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
    }
}
