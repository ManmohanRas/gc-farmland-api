namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IFarmEsmtAttachmentARepository
{
    /// <summary>
    /// get Attachment A details
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    Task<IEnumerable<FarmEsmtAttachmentAEntity>> GetEsmtAttachmentAAsync(int applicationId);

    /// <summary>
    /// save Attachment A details
    /// </summary>
    /// <param name="AttachmentADetails"></param>
    /// <returns></returns>
    Task<FarmEsmtAttachmentAEntity> SaveEsmtAttachmentADetailsAsync(FarmEsmtAttachmentAEntity AttachmentADetails);

    /// <summary>
    /// Delete Attachment A
    /// </summary>
    /// <param name="AttachmentADetails"></param>
    /// <returns></returns>
    Task DeleteEsmtAttachmentADetailsAsync(FarmEsmtAttachmentAEntity AttachmentADetails);

}
