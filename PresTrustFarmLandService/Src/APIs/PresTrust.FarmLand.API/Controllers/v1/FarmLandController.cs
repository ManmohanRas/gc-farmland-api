namespace PresTrust.FarmLand.API.Controllers.v1
{
    [Route("api/v1/farm")]
    [ApiController]
    public class FarmLandController: ControllerBase
    {
        private readonly IMediator _mediator;

        public FarmLandController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        //test api call without Dependency injection / repository pattern
        [HttpGet("test")]
        public int[] GetData() {
            
            return new int[] {1,2,3};   
        }

        [HttpPost("getApplications")]
        public async Task<ActionResult<IEnumerable<GetApplicationsQueryViewModel>>> GetApplications([FromBody] GetApplicationsQuery query)
        {
            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
