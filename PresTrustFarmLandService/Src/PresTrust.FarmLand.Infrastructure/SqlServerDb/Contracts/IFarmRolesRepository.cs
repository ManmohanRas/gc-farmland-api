namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IFarmRolesRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    Task<List<FarmRolesEntity>> GetRolesAsync(int applicationId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationUsers"></param>
    /// <returns></returns>
    Task SaveAsync(List<FarmRolesEntity> applicationUsers);
}
