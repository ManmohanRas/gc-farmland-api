namespace PresTrust.FarmLand.API.Controllers.v1;

[Route("api/v1/farm-term")]
[ApiController]
public class FarmTermController : FarmController
{
    public FarmTermController(IMediator mediator) : base(mediator) { }

    [HttpPost("getTermAppDetails")]
    [ProducesResponseType(typeof(GetTermApplicationDetailsQueryViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetTermApplicationDetailsQueryViewModel>> getTermAppDetails([FromBody] GetTermApplicationDetailsQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("getTermSiteCharacteristics")]
    [ProducesResponseType(typeof(GetSiteCharacteristicsQueryViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetSiteCharacteristicsQueryViewModel>> GetSiteCharacteristics([FromBody] GetSiteCharacteristicsQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("saveTermSiteCharacteristics")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> SaveSiteCharacteristics([FromBody] SaveSiteCharacteristicsCommand command)
    {
        return Single(await CommandAsync(command));
    }

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

    [HttpPost("getTermAppAdminDetails")]
    [ProducesResponseType(typeof(GetTermAdminDetailsQueryViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetTermAdminDetailsQueryViewModel>> GetTermAppAdminDetails([FromBody] GetTermAdminDetailsQuery query)
    {
        return Single(await QueryAsync(query));
    }
    [HttpPost("saveTermAppAdminDetails")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> SaveTermAppAdminDetails([FromBody] SaveTermAppAdminDetailsCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("getTermAdminDeedDetails")]
    [ProducesResponseType(typeof(GetTermAppAdminDeedDetailsQueryViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetTermAppAdminDeedDetailsQueryViewModel>> GetTermAdminDeedDetails([FromBody] GetTermAppAdminDeedDetailsQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("saveTermAppAdminDeedDetails")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> SaveTermAppAdminDeedDetails([FromBody] SaveTermAppAdminDeedDetailsCommand command)
    {
        return Single(await CommandAsync(command));
    }
}
