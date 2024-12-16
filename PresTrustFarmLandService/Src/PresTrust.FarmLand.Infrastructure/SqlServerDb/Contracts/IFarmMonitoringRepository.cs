namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IFarmMonitoringRepository
{
    public Task<IEnumerable<FarmMonitoringEntity>> GetFarmMonitoringAsync();

    public Task<FarmMonitoringEntity> SaveFarmMonitoringAsync(FarmMonitoringEntity farmMonitoring);

}
