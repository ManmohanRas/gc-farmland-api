namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts
{
    public interface IApplicationRepository
    {

        /// <summary>
        /// Get Application by Id
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        Task<FarmLandApplicationEntity> GetApplicationAsync(int applicationId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<FarmLandApplicationEntity>> GetApplicationsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        Task<FarmLandApplicationEntity> SaveAsync(FarmLandApplicationEntity application);
    }
}
