using PresTrust.FarmLand.Application.Commands.SaveFarmEsmtAttachmentA;

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

    [HttpPost("saveAttachmentB")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> saveAttachmentB([FromBody] SaveFarmEsmtAttachmentBCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("deleteAttachmentB")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> deleteAttachmentB([FromBody] DeleteFarmEsmtAttachmentBCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("getEsmtAppExistNonAgreeUses")]
    [ProducesResponseType(typeof(GetEsmtAppExistUsesQueryViewModel),(int)HttpStatusCode.OK)]

    public async Task<ActionResult<GetEsmtAppExistUsesQueryViewModel>> getEsmtAppExistUses([FromBody] GetEsmtAppExistUsesQuery query)
    {
       
        return Single(await QueryAsync(query));

    }

    [HttpPost("saveEsmtAppExistNonAgreeUses")]
    [ProducesResponseType(typeof(int),(int)HttpStatusCode.OK)]
    public async Task<ActionResult< int>> SaveEsmtAppExistUses([FromBody] SaveEsmtAppExistUsesCommand command)
    {
        return Single(await CommandAsync(command));

    }



    [HttpPost("saveAttachmentC")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> saveAttachmentC([FromBody] SaveEsmtAppAttachmentCCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("deleteAttachmentC")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> deleteAttachmentC([FromBody] DeleteEsmtAppAttachmentCCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("GetFarmEsmtAgriEnterprisDetails")]
    [ProducesResponseType(typeof(GetFarmEsmtAgriEnterpriseQueryViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetFarmEsmtAgriEnterpriseQueryViewModel>> GetFarmEsmtAgriEnterprisDetails([FromBody] GetFarmEsmtAgriEnterpriseQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("getEsmtAttachmentD")]
    [ProducesResponseType(typeof(GetAttachmentDQueryViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetAttachmentDQueryViewModel>> GetEsmtAttachmentD([FromBody]  GetAttachmentDQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("saveFarmEsmtAgriEnterpriseDetails")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> saveFarmEsmtAgriEnterpriseDetails([FromBody] SaveFarmEsmtAgriEnterpriseCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("saveEsmtAttachmentD")]
    [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Unit>> SaveEsmtAttachmentD([FromBody] SaveEsmtAttachmentDCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("saveAttachmentE")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> saveAttachmentE([FromBody] SaveEsmtAppAttachmentECommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("saveAttachmentA")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> saveAttachmentA([FromBody] SaveFarmEsmtAttachmentACommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("deleteAttachmentD")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> deleteAttachmentD([FromBody] DeleteAttachmentDCommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("deleteAttachmentE")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> deleteAttachmentE([FromBody] DeleteEsmtAppAttachmentECommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("deleteAttachmentA")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> deleteAttachmentA([FromBody] DeleteFarmEsmtAttachmentACommand command)
    {
        return Single(await CommandAsync(command));
    }

    [HttpPost("getEsmtAppAdminSADC")]
    [ProducesResponseType(typeof(GetEsmtAppAdminSADCQueryViewModel), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<GetEsmtAppAdminSADCQueryViewModel>> getEsmtAppAdminSADC([FromBody] GetEsmtAppAdminSADCQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("saveEsmtAppAdminSADC")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<int>> saveEsmtAppAdminSADC([FromBody] SaveEsmtAppAdminSADCCommand command)
    {
        return Single(await CommandAsync(command));
    }
}
