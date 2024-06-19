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
        /// Delete Municipal User Role.
        /// </summary>
        /// <param name="command"> Query Command.</param>
        /// <returns></returns>
        /// 
        [HttpPost("deleteMunicipalUserRole")]

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

    }
}
