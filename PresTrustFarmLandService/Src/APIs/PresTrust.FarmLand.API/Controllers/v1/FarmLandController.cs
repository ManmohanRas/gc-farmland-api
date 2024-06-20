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
        [HttpPost("getTermFeedbacks")]
        [ProducesResponseType(typeof(IEnumerable<GetTermFeedbacksQueryViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetTermFeedbacksQueryViewModel>>> getApplicationFeedbacks([FromBody] GetTermFeedbacksQuery query)
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
    }
}
