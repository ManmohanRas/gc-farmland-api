namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IFarmEsmtAttachmentBRepository
{
    /// <summary>
    /// get AttachmentB details
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    Task<IEnumerable<FarmEsmtAttachmentBEntity>> GetEsmtAttachmentBAsync(int applicationId);

    /// <summary>
    /// save AttachmentB Details
    /// </summary>
    /// <param name="AttachmentBDetails"></param>
    /// <returns></returns>
    Task<FarmEsmtAttachmentBEntity> SaveEsmtAttachmentBDetailsAsync(FarmEsmtAttachmentBEntity AttachmentBDetails);

    /// <summary>
    /// Delete AttachmentB Details
    /// </summary>
    /// <param name="applicationId"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteEsmtAttachmentBDetailsAsync(FarmEsmtAttachmentBEntity AttachmentBDetails);
}
