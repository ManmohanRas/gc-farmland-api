namespace PresTrust.FarmLand.Infrastructure.SqlServerDb
{
    public interface IEsmtLiensReposioty
    {
        /// <summary>
        /// Get Owner Details.
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        Task<EsmtLiensEntity> GetLiensAsync(int applicationId);
        /// <summary>
        /// Save Owner Details.
        /// </summary>
        /// <param name="FarmOwner"></param>
        /// <returns></returns>
        Task<EsmtLiensEntity> SaveLiensAsync(EsmtLiensEntity FarmOwner);
    }
}
