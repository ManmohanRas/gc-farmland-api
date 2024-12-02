namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IEmailTemplateRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<FarmEmailTemplateEntity>> GetAllEmailTemplates();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<FarmEmailTemplateEntity> GetEmailTemplate(string emailTemplateCode);

    /// <summary>
    /// Save Email Template.
    /// </summary>
    /// <param name="floodEmailTemplate"></param>
    /// <returns></returns>
    Task<FarmEmailTemplateEntity> SaveEmailAsync(FarmEmailTemplateEntity floodEmailTemplate);
}
