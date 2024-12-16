
namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IEsmtAppAttachmentCRepository
{
    /// <summary>
    /// get AttachmentC details
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
   public  Task<IEnumerable< EsmtAppAttachmentCEntity>> GetEsmtAppAttachmentCAsync(int applicationId);


    /// <summary>
    /// Save AttachmentC details
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<EsmtAppAttachmentCEntity> SaveEsmtAppAttachmentCAsync(EsmtAppAttachmentCEntity entity);

    /// <summary>
    /// get AttachmentC details
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task DeleteEsmtAppAttachmentCAsync(EsmtAppAttachmentCEntity entity);

}
