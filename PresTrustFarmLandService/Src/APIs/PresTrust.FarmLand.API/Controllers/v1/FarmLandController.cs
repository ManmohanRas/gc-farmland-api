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

        [HttpPost("getFarmList")]
        [ProducesResponseType(typeof(IEnumerable<GetFarmListQueryViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetFarmListQueryViewModel>>> GetFarmList([FromBody] GetFarmListQuery query)
        {
            return Single(await QueryAsync(query));
        }

        [HttpPost("createApplication")]
        [ProducesResponseType(typeof(CreateApplicationCommandViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateApplicationCommandViewModel>> GetFarmList([FromBody] CreateApplicationCommand query)
        {
            return Single(await CommandAsync(query));
        }
    }
}
