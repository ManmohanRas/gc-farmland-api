namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts
{
    public interface IApplicationRepository
    {

        /// <summary>
        /// Get Application by Id
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        Task<FarmApplicationEntity> GetApplicationAsync(int applicationId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<FarmApplicationEntity>> GetApplicationsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        Task<FarmApplicationEntity> SaveAsync(FarmApplicationEntity application);

        // <summary>
        /// Save Application Status Log
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        Task<bool> SaveStatusLogAsync(FarmApplicationStatusLogEntity applicationStatusLog);
        /// <summary>
        /// Save Application Workflow Status
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        Task<FarmApplicationEntity> SaveApplicationWorkflowStatusAsync(FarmApplicationEntity application);


    }
}
