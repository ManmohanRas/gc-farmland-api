

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface ITermAppAdminContactsRepository
{
    /// <summary>
    ///  Procedure to fetch all contacts by applicationId.
    /// </summary>
    /// <param name="applicationId"> Application Id.</param>
    /// <returns> Returns contacts.</returns>
    /// 

    Task<List<TermAppAdminContactsEntity>> GetAllContactsAsync(int applicationId);

    /// <summary>
    /// Save Contact.
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    /// 
    Task<TermAppAdminContactsEntity> SaveAsync(TermAppAdminContactsEntity contact);

    /// <summary>
    /// Delete Contact.
    /// </summary>
    /// <returns></returns>
    /// 
    Task DeleteContactAsync(TermAppAdminContactsEntity contact);
}
