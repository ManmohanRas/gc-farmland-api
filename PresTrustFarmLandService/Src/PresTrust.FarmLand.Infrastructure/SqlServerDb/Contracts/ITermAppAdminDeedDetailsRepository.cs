namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface ITermAppAdminDeedDetailsRepository
{

    /// <summary>
    ///  Procedure to fetch all contacts by applicationId.
    /// </summary>
    /// <param name="applicationId"> Application Id.</param>
    /// <returns> Returns contacts.</returns>
    /// 

    Task<List<TermAppAdminDeedDetailsEntity>> GetTermAppAdminDeedDetails(int applicationId);

    /// <summary>
    /// Save Contact.
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    /// 
    Task<TermAppAdminDeedDetailsEntity> SaveAsync(TermAppAdminDeedDetailsEntity deedDetails);
}
