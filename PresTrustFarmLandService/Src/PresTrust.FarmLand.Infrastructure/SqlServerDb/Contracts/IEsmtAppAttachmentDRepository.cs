namespace PresTrust.FarmLand.Infrastructure.SqlServerDb
{
    public interface IEsmtAppAttachmentDRepository
    {
        /// <summary>
        ///  Procedure to fetch all Funding source items by applicationId.
        /// </summary>
        /// <param name="applicationId"> Application Id.</param>
        /// <returns> Returns Funding source items.</returns>
        Task<List<FarmEsmtAttachmentDSourseEntity>> GetAttachmentSourcesAsync(int applicationId);
        /// <summary>
        /// Save Funding source item.
        /// </summary>
        /// <param name="actvitySource"></param>
        /// <returns></returns>
        Task<FarmEsmtAttachmentDSourseEntity> SaveAsync(FarmEsmtAttachmentDSourseEntity actvitySource);
        ///// <summary>
        ///// Delete Fudning Source.
        ///// </summary>
        ///// <returns></returns>
        Task DeleteAsync(FarmEsmtAttachmentDSourseEntity acivity);
    }
}
