namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IEsmtAppAdminExceptionRDSORepository
{
    /// <summary>
    /// get Exception/RDSO details
    /// </summary>
    /// <param name="ApplicationId"></param>
    /// <returns></returns>
    Task<EsmtAppAdminExceptionRDSOEntity> GetEsmtAppAdminExceptionRDSODetailsAsync(int ApplicationId);

    /// <summary>
    /// Save SADC Details
    /// </summary>
    /// <param name="exceptionRDSOdetails"></param>
    /// <returns></returns>
    Task<EsmtAppAdminExceptionRDSOEntity> SaveExceptionRDSOdetailsAsync(EsmtAppAdminExceptionRDSOEntity exceptionRDSOdetails);

}
