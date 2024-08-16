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
        public Task<List<FarmApplicationEntity>> GetApplicationsAsync(List<int> agencyIds, bool isExternalUser);

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
        /// <summary>
        /// update application status
        /// </summary>
        /// <param name="application"></param>
        /// <param name="enumStatus"></param>
        /// <returns></returns>
        Task<bool> UpdateApplicationStatusAsync(FarmApplicationEntity application, ApplicationStatusEnum enumStatus);

        /// update application status
        /// </summary>
        /// <param name="application"></param>
        /// <param name="enumStatus"></param>
        /// <returns></returns>
        Task<bool> UpdateSadcAsync(int applicationId);

        /// <summary>
        /// Get Status Log
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        Task<List<FarmApplicationStatusLogEntity>> GetApplicationStatusLogAsync(int applicationId);

    }
}
