using PresTrust.FarmLand.Application.ApiExceptions;

namespace PresTrust.FarmLand.Application
{
    public class BaseHandler
    {
        private TermApplicationPermissionEntity permission = default;
        private readonly IApplicationRepository repoApplication;
        public BaseHandler(IApplicationRepository repoApplication = null) 
        {
            this.repoApplication = repoApplication;
        }

        /// <summary>
        /// Get Application for a given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FarmLandApplicationEntity> GetIfApplicationExists(int id)
        {
            var application = await repoApplication.GetApplicationAsync(id);


            if (application == null)
                throw new EntityNotFoundException($"Application (Id: {id}) does not exist or invalid");

            return application;
        }
    }
}
