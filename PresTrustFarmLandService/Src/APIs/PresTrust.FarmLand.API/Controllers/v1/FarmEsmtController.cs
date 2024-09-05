namespace PresTrust.FarmLand.API.Controllers.v1;

[Route("api/v1/farm-esmt")]
[ApiController]
public class FarmEsmtController : FarmController
{
    public FarmEsmtController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("getEsmtAppDetails")]
    [ProducesResponseType(typeof(GetEsmtApplicationDetailsQueryViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetEsmtApplicationDetailsQueryViewModel>> getTermAppDetails([FromBody] GetEsmtApplicationDetailsQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("getEsmtOwnerDetails")]
    [ProducesResponseType(typeof(GetEsmtOwnerDetailsQueryViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetEsmtOwnerDetailsQueryViewModel>> GetEsmtOwnerDetails([FromBody] GetEsmtOwnerDetailsQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("SaveEsmtOwnerDetails")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> SaveEsmtOwnerDetails([FromBody] SaveEsmtOwnerDetailsCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("getEsmtExceptions")]
    [ProducesResponseType(typeof(GetFarmEsmtExceptionsQueryViewModel), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<GetFarmEsmtExceptionsQueryViewModel>> getEsmtExceptions([FromBody] GetFarmEsmtExceptionsQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("saveEsmtExceptions")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<int>> saveEsmtExceptions([FromBody] SaveFarmEsmtExceptionsCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("getEsmtLiens")]
    [ProducesResponseType(typeof(GetEsmtLiensQueryViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetEsmtLiensQueryViewModel>> GetEsmtLiens([FromBody] GetEsmtLiensQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("SaveEsmtLiens")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> SaveEsmtLiens([FromBody] SaveEsmtLiensCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("getEsmtAppStructure")]
    [ProducesResponseType(typeof(GetEsmtAppStructureQueryViewModel), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<GetEsmtAppStructureQueryViewModel>> GetEsmtAppStructure([FromBody] GetEsmtAppStructureQuery query)
    {
        return Single(await QueryAsync(query));


    }

    [HttpPost("saveEsmtAppStructure")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<int>> SaveEsmtAppStructure([FromBody] SaveEsmtAppStructureCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("saveEsmtAppSignatoryDetails")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> SaveEsmtAppSignatoryDetails([FromBody] SaveEsmtAppSignatoryCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("getEsmtAppSignatoryDetails")]
    [ProducesResponseType(typeof(GetEsmtAppSignatoryQueryViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetEsmtAppSignatoryQueryViewModel>> GetEsmtAppSignatoryDetails([FromBody] GetEsmtAppSignatoryQuery query)
    {
        return Single(await QueryAsync(query));
    }
}
