namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;
public interface IEsmtAppAttachmentERepository
{
    /// <summary>
    /// get Attachment E details
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    public Task<IEnumerable<EsmtAppAttachmentEEntity>> GetEsmtAppAttachmentEAsync(int ApplicationId);
    /// <summary>
    /// save AttachmentE details
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<EsmtAppAttachmentEEntity> SaveEsmtAppAttachmentEAsync(EsmtAppAttachmentEEntity request);

    /// <summary>
    /// Delete AttachmentE details
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task DeleteEsmtAppAttachmentEAsync(EsmtAppAttachmentEEntity request);
}
