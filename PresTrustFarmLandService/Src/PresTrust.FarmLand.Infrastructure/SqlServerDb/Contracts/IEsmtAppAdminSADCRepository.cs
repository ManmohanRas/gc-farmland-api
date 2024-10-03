namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IEsmtAppAdminSADCRepository
{
    /// <summary>
    /// get SADC Details
    /// </summary>
    /// <param name="ApplicationId"></param>
    /// <returns></returns>
    Task<EsmtAppAdminSADCEntity> GetEsmtAppAdminSADCDetailsAsync(int ApplicationId);

    /// <summary>
    /// Save SADC Details
    /// </summary>
    /// <param name="SADCdetails"></param>
    /// <returns></returns>
    Task<EsmtAppAdminSADCEntity> SaveSADCdetailsAsync(EsmtAppAdminSADCEntity SADCdetails);
}
