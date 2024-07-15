namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IEmailTemplateRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<FarmEmailTemplateEntity> GetEmailTemplate(string emailTemplateCode);
}
